using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models
{
    public class ItemTemplate
    {

        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public UnitType UnitType { get; set; }
        public string Description { get; set; }
        public ICollection<ItemPropertyCategory> Properties { get; set; }
        public ICollection<ItemTemplate> Parts { get; set; }

    }
}