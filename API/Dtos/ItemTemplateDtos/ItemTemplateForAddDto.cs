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
        public int RevisionId { get; set; }
        public System.DateTime Created { get; set; }
        public ItemTemplate RevisionedFrom;
        public int[] Files { get; set; }
        public string[] FileNames { get; set;}
        public bool IsActive { get; set; }
    }
}