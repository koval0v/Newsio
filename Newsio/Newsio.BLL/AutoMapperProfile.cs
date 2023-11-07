using AutoMapper;
using Newsio.BLL.Dtos;
using Newsio.DAL.Entities;

namespace Newsio.BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();

            CreateMap<News, NewsDto>()
                .ForMember(um => um.Tags, x => x.MapFrom(u => u.NewsTags.Select(p => p.Tag)))
                .ReverseMap();

            CreateMap<NewsTag, NewsTagDto>()
                .ReverseMap();

            CreateMap<Section, SectionDto>()
                .ReverseMap();

            CreateMap<Tag, TagDto>()
                .ReverseMap();
        }
    }
}
