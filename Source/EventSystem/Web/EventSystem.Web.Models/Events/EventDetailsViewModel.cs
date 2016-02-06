namespace EventSystem.Web.Models.Events
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using EventSystem.Models;
    using Infrastructure.Mappings;


    public class EventDetailsViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime CreatedOn { get; set; }

        public Place Place { get; set; }

        public string CategoryName { get; set; }

        public string UserName { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Event, EventDetailsViewModel>("testProfile")
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.UserName))
                 .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category.Name))
                 .ReverseMap();
        }
    }
}
