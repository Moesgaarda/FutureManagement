using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models{
    public class Order{
        public Order(){
            this.OrderDate = DateTime.Now;
        }
        public Order(string company, DateTime orderDate, DateTime deliveryDate, User orderedBy, 
            int purchaseNumber, int width, int height, int length, UnitType unitType, ICollection<Item> products, ICollection<OrderFileName> files){

            this.Company = company;
            this.OrderDate = DateTime.Now;
            this.DeliveryDate = deliveryDate;
            this.OrderedBy = orderedBy;
            this.PurchaseNumber = purchaseNumber;
            this.Width = width;
            this.Height = height;
            this.Length = length;
            this.UnitType = unitType;
            this.Products = products;
            this.Files = files;
        }

        public Order(int id, string company, DateTime orderDate, DateTime deliveryDate, User orderedBy,
            int purchaseNumber, int width, int height, int length, UnitType unitType, ICollection<Item> products){

            this.Id = id;
            this.Company = company;
            this.OrderDate = DateTime.Now;
            this.DeliveryDate = deliveryDate;
            this.OrderedBy = orderedBy;
            this.PurchaseNumber = purchaseNumber;
            this.Width = width;
            this.Height = height;
            this.Length = length;
            this.UnitType = unitType;
            this.Products = products;
        }

        [Key]
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public User OrderedBy { get; set; }
        public int PurchaseNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public UnitType UnitType { get; set; }
        public ICollection<Item> Products { get; set; }
        public ICollection<OrderFileName> Files { get; set; }
        public OrderStatus Status { get; set; }
        public bool InternalOrder { get; set; }

        /* If the order is internal, it should have an assigned user */
        public User AssignedUser { get; set; }
        public User SignedBy { get; set; }

    }
}