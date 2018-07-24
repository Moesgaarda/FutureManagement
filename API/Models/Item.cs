using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class Item{
        public Item(){}
        public Item(int id, string placement, int amount, ItemTemplate template, Order order, User createdBy,
            ICollection<ItemPropertyDescription> properties, ICollection<Item> parts, bool isActive){

            this.Id = id;
            this.Placement = placement;
            this.Amount = amount;
            this.Template = template;
            this.Order = order;
            this.CreatedBy = createdBy;
            this.Properties = Properties;
            this.Parts = parts;
            this.IsActive = isActive;
        }
        public Item(string placement, int amount, ItemTemplate template, Order order, User createdBy, 
            ICollection<ItemPropertyDescription> properties, ICollection<Item> parts, bool isActive){

            this.Placement = placement;
            this.Amount = amount;
            this.Template = template;
            this.Order = order;
            this.CreatedBy = createdBy;
            this.Properties = Properties;
            this.Parts = parts;
            this.IsActive = isActive;
        }
        
        [Key]
        public int Id { get; private set; }
        public ICollection<ItemPropertyDescription> Properties { get; set; }
        public string Placement { get; set; }
        public int Amount { get; set; }
        [Required]
        public ItemTemplate Template { get; set; }
        public Order Order { get; set; }
        public User CreatedBy { get; set; } 
        public ICollection<Item> Parts { get; set; }
        public ICollection<Item> PartOf { get; set; }
        public bool IsActive { get; set; }
    }
}