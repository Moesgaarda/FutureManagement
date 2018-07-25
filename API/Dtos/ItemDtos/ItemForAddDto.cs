using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models;

namespace API.Dtos
{
    public class ItemForAddDto
    {
        public string Placement { get; set; }
        public int Amount { get; set; }
        [ForeignKey("Template")]
        public ItemTemplate Template { get; set; }
        [ForeignKey("Order")]
        public Order Order { get; set; }
        [ForeignKey("CreatedBy")]
        public User CreatedBy { get; set; }
        public ICollection<Item> Parts { get; set; }
        public ICollection<Item> PartOf { get; set; }
        public ICollection<ItemPropertyDescription> Properties { get; set; }
        public bool IsActive { get; set; }
    }
}