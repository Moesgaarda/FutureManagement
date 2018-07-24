using AutoMapper;
using API.Models;
using API.Dtos;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ItemTemplate, ItemTemplateForGetDto>();
            CreateMap<ItemTemplate, ItemTemplateForAddDto>();
            CreateMap<ItemTemplate, ItemTemplateForTableDto>();
            CreateMap<ItemTemplate, ItemTemplatePartForGetDto>();
            CreateMap<ItemTemplate, ItemTemplatePartOfForGetDto>();
            CreateMap<ItemTemplatePart, ItemTemplatePartDto>();
            CreateMap<ItemTemplatePart, ItemTemplatePartOfDto>();
            CreateMap<ItemPropertyName, ItemPropertyNameForAddDto>();
            CreateMap<ItemPropertyName, ItemPropertyNameForGetDto>();
            CreateMap<TemplateProperty, TemplatePropertyForGetDto>()
                .ForMember(x => x.PropertyName, opt => 
                    opt.MapFrom(src => src.Property.Name));
        }
    }
}