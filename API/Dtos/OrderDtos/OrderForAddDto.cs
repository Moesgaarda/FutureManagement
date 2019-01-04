using System;
using System.Collections.Generic;
using API.Models;
using API.Enums;

namespace API.Dtos.OrderDtos
{
    public class OrderForAddDto
    {
        public string Company { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public User OrderedBy { get; set; }
        public string InvoicePath { get; set; }
        public int PurchaseNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public string UnitType { get; set; }
        public List<Item> Products { get; set; }
        public int[] Files { get; set; }
        public string[] FileNames { get; set; }
        public OrderStatusEnum Status { get; set; }
        public bool InternalOrder { get; set; }
    }
}