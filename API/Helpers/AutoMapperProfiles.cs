using AutoMapper;
using API.Dtos;
using API.Models;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ItemTemplate, ItemTemplateForGetDto>();
            CreateMap<ItemTemplate, ItemTemplateForAddDto>();
            CreateMap<ItemTemplate, ItemTemplateForTableDto>();
            CreateMap<ItemPropertyName, ItemTemplatePropertyForAddDto>();
        }
    }
}