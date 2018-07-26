using System.Collections.Generic;
using API.Dtos.UserDtos;
using API.Models;

namespace API.Dtos
{
    public class ItemForGetDto
    {
        public int Id { get; set; }
        public ICollection<ItemPropertyDescription> Properties { get; set; }
        public string Placement { get; set; }
        public int Amount { get; set; }
        public ItemTemplateForTableDto Template { get; set; }
        public Order Order { get; set; }
        public UserForGetDto CreatedBy { get; set; } 
        public ICollection<ItemItemRelationForGet> Parts { get; set; }
        public ICollection<ItemItemRelationForGet> PartOf { get; set; }
        public bool IsActive { get; set; }
    }
}