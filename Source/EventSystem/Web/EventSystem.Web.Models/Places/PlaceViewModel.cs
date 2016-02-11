namespace EventSystem.Web.Models.Places
{
    using System;
    using AutoMapper;
    using EventSystem.Models;
    using EventSystem.Web.Infrastructure.Mappings;

    public class PlaceViewModel : IMapFrom<Place>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public string Street { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Place, PlaceViewModel>()
                .ForMember(d => d.CountryName, opt => opt.MapFrom(s => s.Country.Name))
                 .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.City.Name))
                 .ReverseMap();
        }
    }
}
