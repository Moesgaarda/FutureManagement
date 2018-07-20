using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Enums;
using API.Models;

namespace API.Dtos
{
    public class ItemTemplateForAddDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public UnitType UnitType { get; set; }
        public string Description { get; set; }
        public ICollection<TemplateProperty> TemplateProperties { get; set; }
        public ICollection<ItemTemplate> Parts { get; set; }
        public string Files { get; set; }

    }
}