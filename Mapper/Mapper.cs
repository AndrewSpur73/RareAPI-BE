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
            CreateMap<Comment, CreateCommentDTO>().ReverseMap();
            CreateMap<Post, CreatePostDTO>()
                .ForMember(dest => dest.TagIds, opt => opt.MapFrom(src => src.PostTags.Select(sg => sg.Tag)))
                .ReverseMap();
            //Update data DTOs
            CreateMap<Comment, EditCommentDTO>().ReverseMap();
<<<<<<< Updated upstream
            CreateMap<Post, UpdatePostDTO>()
                .ForMember(dest => dest.EditTags, opt => opt.MapFrom(src => src.PostTags.Select(sg => sg.Tag)))
                .ReverseMap();
=======
            CreateMap<Tag, EditTagDTO>().ReverseMap();
>>>>>>> Stashed changes

            //Get data DTOs
            
        }
    }
}
