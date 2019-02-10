using System.Collections.Generic;
using API.Dtos;
using API.Models;

namespace API.Dtos
{
    public class ItemForGetDto
    {
        public int Id { get; set; }
        public ICollection<ItemPropertyDescriptionForGetDto> Properties { get; set; }
        public string Placement { get; set; }
        public int Amount { get; set; }
        public ItemTemplateForTableDto Template { get; set; }
        public OrderForTableDto Order { get; set; }
        public UserForItemGetDto CreatedBy { get; set; } 
        public ICollection<ItemItemRelationForGet> Parts { get; set; }
        public ICollection<ItemItemRelationPartOfForGet> PartOf { get; set; }
        public bool IsActive { get; set; }
    }
}