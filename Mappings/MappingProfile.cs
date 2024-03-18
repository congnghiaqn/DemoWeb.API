using AutoMapper;
using DemoWeb.API.Models.Domain;
using DemoWeb.API.Models.DTO;

namespace DemoWeb.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
