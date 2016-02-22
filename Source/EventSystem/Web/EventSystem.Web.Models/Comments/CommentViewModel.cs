namespace EventSystem.Web.Models.Comments
{
    using System;

    using AutoMapper;
    using EventSystem.Models;
    using Infrastructure.Mappings;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.UserName));
        }
    }
}
