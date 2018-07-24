using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.Dtos
{
    public class ItemForAddDto
    {
        public ICollection<ItemPropertyDescription> Properties { get; set; }
        public string Placement { get; set; }
        public int Amount { get; set; }
        [Required]
        public ItemTemplate Template { get; set; }
        public Order Order { get; set; }
        public User CreatedBy { get; set; }
        public ICollection<Item> Parts { get; set; }

        public bool IsArchived { get; set; }
    }
}