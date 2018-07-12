using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Company { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        [Required]
        public User OrderedBy { get; set; }
        public string InvoicePath { get; set; }
        public int PurchaseNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public UnitType UnitType { get; set; }
        [Required]
        public ICollection<Item> Products { get; set; }
    }
}