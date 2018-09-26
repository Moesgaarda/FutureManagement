using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Enums;
using API.Models;

namespace API.Dtos
{
    public class ItemTemplateForAddDto
    {

        public ItemTemplateForAddDto(){
            IsActive = true;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public UnitType UnitType { get; set; }
        public string Description { get; set; }
        public ICollection<ItemPropertyNameForGetDto> TemplateProperties { get; set; }
        public ICollection<ItemTemplatePart> Parts { get; set; }
        public ICollection<ItemTemplatePart> PartOf { get; set; }
        public ICollection<int> Files { get; set; }
        public bool IsActive { get; set; }
    }
}