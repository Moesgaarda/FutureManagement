using System.Collections.Generic;
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
        public ICollection<TemplateFileDataRelation> Files { get; set; }
    }
}