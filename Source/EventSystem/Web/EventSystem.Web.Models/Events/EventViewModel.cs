namespace EventSystem.Web.Models.Events
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using EventSystem.Models;
    using EventSystem.Web.Infrastructure.Mappings;
    using Images;

    public class EventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime EventStart { get; set; }

        public string PlaceName { get; set; }

        public string CategoryName { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                 .ForMember(d => d.PlaceName, opt => opt.MapFrom(s => s.Place.Name))
                  .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category.Name));
        }
    }
}
