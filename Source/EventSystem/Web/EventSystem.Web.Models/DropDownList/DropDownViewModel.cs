namespace EventSystem.Web.Models.DropDownList
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;
    using Data.Common.Models;
    using Infrastructure.Mappings;

    public class DropDownViewModel : IMapFrom<IListedItem>, IHaveCustomMappings
    {
        public int? SelectedValue { get; set; }

        public IEnumerable<SelectListItem> Items { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<IListedItem, SelectListItem>()
                 .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Name))
                 .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id.ToString()));
        }
    }
}
