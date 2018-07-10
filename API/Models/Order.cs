using System;
using System.Collections.Generic;
using API.Enums;

namespace API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public User OrderedBy { get; set; }
        public string InvoicePath { get; set; }
        public int PurchaseNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public UnitType UnitType { get; set; }
        public List<Item> Products { get; set; }
    }
}