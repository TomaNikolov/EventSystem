namespace EventSystem.Web.Models.Orders
{
    using System;
    using AutoMapper;
    using EventSystem.Models;
    using Infrastructure.Mappings;

    public class OrderedTicketViewModel : IMapFrom<Ticket>, IHaveCustomMappings
    {
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime StartDate { get; set; }

        public int EventId { get; set; }

        public string EventTitle { get; set; }

        public string PlaceName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Ticket, OrderedTicketViewModel>()
                .ForMember(d => d.StartDate, opt => opt.MapFrom(s => s.Event.EventStart))
                .ForMember(d => d.EventId, opt => opt.MapFrom(s => s.Event.Id))
                .ForMember(d => d.EventTitle, opt => opt.MapFrom(s => s.Event.Title))
                .ForMember(d => d.PlaceName, opt => opt.MapFrom(s => s.Event.Place.Name));
        }
    }
}
