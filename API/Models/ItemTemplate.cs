using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models
{
    public class ItemTemplate
    {
        public ItemTemplate(int id, string name, UnitType unitType, string description, 
                            List<ItemPropertyCategory> properties, List<ItemTemplate> parts){
            Id = id;
            Name = name;
            UnitType = unitType;
            Description = description;
            if(properties == null){
                properties = new List<ItemPropertyCategory>();
            }
            Properties = properties;
            if(parts == null){
                parts = new List<ItemTemplate>();
            }
            Parts = parts;
        }
        public ItemTemplate(string name, UnitType unitType, string description, 
                            List<ItemPropertyCategory> properties, List<ItemTemplate> parts){
            Name = name;
            UnitType = unitType;
            Description = description;
            if(properties == null){
                properties = new List<ItemPropertyCategory>();
            }
            Properties = properties;
            if(parts == null){
                parts = new List<ItemTemplate>();
            }
            Parts = parts;
        }
        public int Id { get; }
        [Required]
        public string Name { get; set; }
        [Required]
        public UnitType UnitType { get; set; }
        public string Description { get; set; }
        public List<ItemPropertyCategory> Properties { get; set; }
        public List<ItemTemplate> Parts { get; set; }

    }
}