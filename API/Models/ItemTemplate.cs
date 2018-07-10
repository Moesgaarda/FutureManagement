using System;
using System.Collections.Generic;
using API.Enums;

namespace API.Models
{
    public class ItemTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UnitType UnitType { get; set; }
        public string Description { get; set; }
        public List<ItemProperty> Properties { get; set; }
        public List<ItemTemplate> Parts { get; set; }

    }
}