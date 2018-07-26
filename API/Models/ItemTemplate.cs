using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using API.Enums;
using Newtonsoft.Json;

namespace API.Models{
    public class ItemTemplate{
        public ItemTemplate(){}
        public ItemTemplate(int id, string name, UnitType unitType, string description, ICollection<TemplatePropertyRelation> properties, ICollection<ItemTemplatePart> parts, string files){
            this.Id = id;
            this.Name = name;
            this.UnitType = unitType;
            this.Description = description;
            this.TemplateProperties = properties;
            this.Parts = parts;
            this.Files = files;
        }

        public ItemTemplate(string name, UnitType unitType, string description, ICollection<TemplatePropertyRelation> properties, ICollection<ItemTemplatePart> parts, string files){
            this.Name = name;
            this.UnitType = unitType;
            this.Description = description;
            this.TemplateProperties = properties;
            this.Parts = parts;
            this.Files = files;
        }
        
        [Key]
        public int Id { get;  set; }
        public string Name { get; set; }
        public UnitType UnitType { get; set; }
        public string Description { get; set; }
        public ICollection<TemplatePropertyRelation> TemplateProperties { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ItemTemplatePart> Parts { get; set; }
        public ICollection<ItemTemplatePart> PartOf { get; set; }
        public string Files { get; set; }

    }
}