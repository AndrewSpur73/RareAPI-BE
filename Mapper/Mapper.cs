using RareAPI_BE.Models;
using RareAPI_BE.DTOs;
using AutoMapper;

namespace RareAPI_BE.Mapper
{
    public class MapperProfile : Profile 
    {
        public MapperProfile() 
        {
            //Create data DTOs
            CreateMap<Tag, CreateTagDTO>().ReverseMap();
            CreateMap<Comment, CreateCommentDTO>().ReverseMap();
            CreateMap<Post, CreatePostDTO>()
                .ForMember(dest => dest.TagIds, opt => opt.MapFrom(src => src.PostTags.Select(sg => sg.Tag)))
                .ReverseMap();

            //Update data DTOs
            CreateMap<Comment, EditCommentDTO>().ReverseMap();
            CreateMap<Post, UpdatePostDTO>()
                .ForMember(dest => dest.TagIds, opt => opt.MapFrom(src => src.PostTags.Select(sg => sg.Tag)))
                .ReverseMap();
            CreateMap<Tag, EditTagDTO>().ReverseMap();
            


            //Get data DTOs
            
        }
    }
}
