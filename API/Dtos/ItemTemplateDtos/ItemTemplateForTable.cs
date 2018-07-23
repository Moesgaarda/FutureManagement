using System.Collections.Generic;
using API.Enums;
using API.Models;

namespace API.Dtos
{
    public class ItemTemplateForTableDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UnitType UnitType { get; set; }
        public string Description { get; set; }
        public string Files { get; set; }
    }
}