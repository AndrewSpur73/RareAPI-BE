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

            //Update data DTOs
            CreateMap<Comment, EditCommentDTO>().ReverseMap();

            //Get data DTOs

        }
    }
}
