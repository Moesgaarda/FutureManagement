using System.Collections.Generic;
using API.Dtos.FileDtos;
using API.Enums;
using API.Models;

namespace API.Dtos
{
    public class ItemTemplateForGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UnitType UnitType { get; set; }
        public string Description { get; set; }
        public ICollection<TemplatePropertyForGetDto> TemplateProperties { get; set; }
        public ICollection<ItemTemplatePartDto> Parts { get; set; }
        public ICollection<ItemTemplatePartOfDto> PartOf { get; set; }
        public ICollection<FileNameForGetDto> Files { get; set; }
        public ItemTemplateForGetDto RevisionedFrom { get; set; }
        public int LowerLimit { get; set; }
        public ItemTemplateCategory Category { get; set; }
    }
}