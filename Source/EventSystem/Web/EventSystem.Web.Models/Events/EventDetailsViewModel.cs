﻿namespace EventSystem.Web.Models.Events
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using Comments;
    using EventSystem.Models;
    using Images;
    using Infrastructure.Mappings;
    using Tickets;

    public class EventDetailsViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime CreatedOn { get; set; }

        public Place Place { get; set; }

        public string CategoryName { get; set; }

        public string UserName { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }

        public ICollection<TicketViewModel> Tickets { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventDetailsViewModel>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.UserName))
                 .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category.Name))
                 .ReverseMap();
        }
    }
}
