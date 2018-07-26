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
            CreateMap<TemplatePropertyRelation, TemplatePropertyForGetDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Property.Name))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.PropertyId));
            CreateMap<Item, ItemForTableGetDto>();
        }
    }
}