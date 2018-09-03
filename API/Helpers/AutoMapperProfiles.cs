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
            CreateMap<ItemTemplate, ItemTemplateForItemGetDto>();
            CreateMap<ItemTemplatePart, ItemTemplatePartDto>();
            CreateMap<ItemTemplatePart, ItemTemplatePartOfDto>();
            CreateMap<ItemPropertyName, ItemPropertyNameForAddDto>();
            CreateMap<ItemPropertyName, ItemPropertyNameForGetDto>();
            CreateMap<ItemPropertyDescription, ItemPropertyDescriptionForGetDto>();
            CreateMap<TemplatePropertyRelation, TemplatePropertyForGetDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Property.Name))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.PropertyId));
            CreateMap<Item, ItemForTableGetDto>();
            CreateMap<TemplatePropertyRelation, ItemPropertyNameForGetDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.PropertyId));
            CreateMap<Item, UserForItemGetDto>();
            CreateMap<Order, OrderForGetDto>();
            CreateMap<ItemItemRelation, ItemItemRelationPartOfForGet>();
            CreateMap<ItemItemRelation, ItemItemRelationForGet>()
                .ForMember(x => x.Template, opt => opt.MapFrom(src => src.Part.Template));
            CreateMap<User, UserForGetDto>();
        }
    }
}