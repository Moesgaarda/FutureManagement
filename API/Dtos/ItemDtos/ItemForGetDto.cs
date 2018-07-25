using System.Collections.Generic;
using API.Models;

namespace API.Dtos
{
    public class ItemForGetDto
    {
        public int Id { get; set; }
        public ICollection<ItemPropertyDescription> Properties { get; set; }
        public string Placement { get; set; }
        public int Amount { get; set; }
        public ItemTemplate Template { get; set; }
        public Order Order { get; set; }
        public User CreatedBy { get; set; } 
        public ICollection<Item> Parts { get; set; }
        public ICollection<Item> PartOf { get; set; }
        public bool IsActive { get; set; }
    }
}