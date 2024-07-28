using AutoMapper;
using BlogApp.Domain.Entities;
using BlogApp.Application.DTO;

namespace BlogApp.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
