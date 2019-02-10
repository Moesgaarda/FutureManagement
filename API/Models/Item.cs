using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models{
    public class Item{
        public Item(){}
        public Item(int id, string placement, int amount, ItemTemplate template, Order order, User createdBy,
            ICollection<ItemPropertyDescription> properties, ICollection<ItemItemRelation> parts, ICollection<ItemItemRelation> partOf, bool isActive){

            this.Id = id;
            this.Placement = placement;
            this.Amount = amount;
            this.Template = template;
            this.Order = order;
            this.CreatedBy = createdBy;
            this.Properties = properties;
            this.Parts = parts;
            this.PartOf = partOf;
            this.IsActive = isActive;
        }
        
        public Item(string placement, int amount, ItemTemplate template, Order order, User createdBy, 
            ICollection<ItemPropertyDescription> properties, ICollection<ItemItemRelation> parts, ICollection<ItemItemRelation> partOf, bool isActive){

            this.Placement = placement;
            this.Amount = amount;
            this.Template = template;
            this.Order = order;
            this.CreatedBy = createdBy;
            this.Properties = properties;
            this.Parts = parts;
            this.PartOf = partOf;
            this.IsActive = isActive;
        }
        
        [Key]
        public int Id { get; set; }
        public ICollection<ItemPropertyDescription> Properties { get; set; }
        public string Placement { get; set; }
        public int Amount { get; set; }
        public ItemTemplate Template { get; set; }
        public Order Order { get; set; }
        public User CreatedBy { get; set; } 
        public ICollection<ItemItemRelation> Parts { get; set; }
        public ICollection<ItemItemRelation> PartOf { get; set; }
        public bool? IsActive { get; set; }  
    }
}