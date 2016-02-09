﻿namespace EventSystem.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;
    using Infrastructure;
    using Infrastructure.Constants;
    using Infrastructure.Mappings;

    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            var viewModelTypes = Assembly.Load(Assemblies.ViewModels).GetExportedTypes();

            var config = new MapperConfiguration(cfg =>
            {
                LoadStandardMappings(cfg, types);
                LoadStandardMappings(cfg, viewModelTypes);

                LoadCustomMappings(cfg, types);
                LoadCustomMappings(cfg, viewModelTypes);
            });

            MapperFactory.InititializeMapper(config);
        }

        private static void LoadStandardMappings(IMapperConfiguration config, IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                config.CreateMap(map.Source, map.Destination);

                config.CreateMap(map.Destination, map.Source);
            }
        }

        private static void LoadCustomMappings(IMapperConfiguration config, IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(config);
            }
        }
    }
}