using System;
using System.Collections.Generic;
using API.Enums;

namespace API.Models
{
    public class Order
    {
        public Order(string company, DateTime orderDate, DateTime deliveryDate, User orderedBy, string invoicePath, int purchaseNumber,
        int width, int height, int length, UnitType unitType, List<Item> products){
            Company = company;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            OrderedBy = orderedBy;
            InvoicePath = invoicePath;
            PurchaseNumber = purchaseNumber;
            Width = width;
            Height = height;
            Length = length;
            UnitType = unitType;
            Products = products;
        }

        public Order(int id, string company, DateTime orderDate, DateTime deliveryDate, User orderedBy, string invoicePath, int purchaseNumber,
        int width, int height, int length, UnitType unitType, List<Item> products){
            Id = id;
            Company = company;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            OrderedBy = orderedBy;
            InvoicePath = invoicePath;
            PurchaseNumber = purchaseNumber;
            Width = width;
            Height = height;
            Length = length;
            UnitType = unitType;
            Products = products;
        }

        public int Id { get; }
        [Required]
        public string Company { get; set; }
        [DateTime]
        public DateTime OrderDate { get; set; }
        [DateTime]
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
        public List<Item> Products { get; set; }
    }
}