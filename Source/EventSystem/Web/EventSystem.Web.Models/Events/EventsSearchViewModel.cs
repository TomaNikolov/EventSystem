namespace EventSystem.Web.Models.Events
{
    using System;
    using AutoMapper;
    using EventSystem.Models;
    using EventSystem.Web.Infrastructure.Mappings;

    public class EventsSearchViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime EventStart { get; set; }

        public string PlaceName { get; set; }

        public string CategoryName { get; set; }

        public string CityName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventsSearchViewModel>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category.Name))
                .ForMember(d => d.PlaceName, opt => opt.MapFrom(s => s.Place.Name))
                .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.Place.City.Name))
                .ReverseMap();
        }
    }
}
