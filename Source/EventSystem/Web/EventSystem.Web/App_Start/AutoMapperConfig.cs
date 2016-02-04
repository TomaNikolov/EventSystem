﻿namespace EventSystem.Web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;
    using Infrastructure.Constants;
    using Infrastructure.Mappings;

    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            var viewModelTypes = Assembly.Load(Assemblies.ViewModels).GetExportedTypes();

            LoadStandardMappings(types);
            LoadStandardMappings(viewModelTypes);

            LoadCustomMappings(types);
            LoadCustomMappings(viewModelTypes);
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
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
#pragma warning disable CS0618 // Type or member is obsolete
                Mapper.CreateMap(map.Source, map.Destination);

                Mapper.CreateMap(map.Destination, map.Source);
#pragma warning restore CS0618 // Type or member is obsolete
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                map.CreateMappings(Mapper.Configuration);
#pragma warning restore CS0618 // Type or member is obsolete
            }
        }
    }
}