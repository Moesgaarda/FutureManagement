using System.Collections.Generic;
using API.Dtos;
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
        public OrderForGetDto Order { get; set; }
        public UserForItemGetDto CreatedBy { get; set; } 
        public ICollection<ItemItemRelationForGet> Parts { get; set; }
        public ICollection<ItemItemRelationForGet> PartOf { get; set; }
        public bool IsActive { get; set; }
    }
}