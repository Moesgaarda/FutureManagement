using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models{
    public class ItemTemplate{
        public ItemTemplate(){}
        public ItemTemplate(int id, string name, UnitType unitType, string description, ICollection<ItemPropertyCategory> properties, ICollection<ItemTemplate> parts){
            this.Id = id;
            this.Name = name;
            this.UnitType = unitType;
            this.Description = description;
            this.Properties = properties;
            this.Parts = parts;
        }

        public ItemTemplate(string name, UnitType unitType, string description, ICollection<ItemPropertyCategory> properties, ICollection<ItemTemplate> parts){
            this.Name = name;
            this.UnitType = unitType;
            this.Description = description;
            this.Properties = properties;
            this.Parts = parts;
        }
        
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public UnitType UnitType { get; set; }
        public string Description { get; set; }
        public ICollection<ItemPropertyCategory> Properties { get; set; }
        public ICollection<ItemTemplate> Parts { get; set; }

    }
}