using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models{
    public class ItemTemplate{
        public ItemTemplate(){}
        public ItemTemplate(int id, string name, UnitType unitType, string description, ICollection<ItemPropertyCategory> properties, ICollection<ItemTemplate> parts, string files){
            this.Id = id;
            this.Name = name;
            this.UnitType = unitType;
            this.Description = description;
            this.Properties = properties;
            this.Parts = parts;
            this.Files = files;
        }

        public ItemTemplate(string name, UnitType unitType, string description, ICollection<ItemPropertyCategory> properties, ICollection<ItemTemplate> parts, string files){
            this.Name = name;
            this.UnitType = unitType;
            this.Description = description;
            this.Properties = properties;
            this.Parts = parts;
            this.Files = files;
        }
        
        [Key]
        public int? Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public UnitType UnitType { get; set; }
        public string Description { get; set; }
        public ICollection<ItemPropertyCategory> Properties { get; set; }
        public ICollection<ItemTemplate> Parts { get; set; }
        public string Files { get; set; }

    }
}