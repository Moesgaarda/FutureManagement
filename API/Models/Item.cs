using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Item
    {
        public Item(int id, List<ItemProperty> properties, string placement, int amount, ItemTemplate template,
                    Order order, User createdBy, List<Item> parts){
            Id = id;            
            if(properties == null){
                properties = new List<ItemProperty>();
            }
            Properties = properties;
            Placement = placement;
            Amount = amount;
            Template = template;
            Order = order;
            CreatedBy = createdBy;
            if(parts == null){
                parts = new List<Item>();
            }
            Parts = parts;    
        }
        public Item(List<ItemProperty> properties, string placement, int amount, ItemTemplate template,
                    Order order, User createdBy, List<Item> parts){         
            if(properties == null){
                properties = new List<ItemProperty>();
            }
            Properties = properties;
            Placement = placement;
            Amount = amount;
            Template = template;
            Order = order;
            CreatedBy = createdBy;
            if(parts == null){
                parts = new List<Item>();
            }
            Parts = parts;    
        }
        public int Id { get; }
        public List<ItemProperty> Properties { get; set; }
        public string Placement { get; set; }
        public int Amount { get; set; }
        [Required]
        public ItemTemplate Template { get; set; }
        public Order Order { get; set; }
        public User CreatedBy { get; set; }
        public List<Item> Parts { get; set; }
    }
}