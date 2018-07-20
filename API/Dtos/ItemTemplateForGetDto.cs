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
        public ICollection<ItemPropertyName> Properties { get; set; }
        public ICollection<ItemTemplate> Parts { get; set; }
        public string Files { get; set; }
    }
}