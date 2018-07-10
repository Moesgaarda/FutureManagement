using System;
using System.Collections.Generic;
using API.Enums;

namespace API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Item> Products {get; set;}
        public string DeliveryAddress { get; set; }
        public string DeliveryCountry { get; set; }
        public string Comments { get; set; }
        public int InvoiceNumber { get; set; }
        public Calculator Calculator { get; set; }
        public Status Status { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public UnitType UnitType { get; set; }
        public string Usage { get; set; }
        public int OrderNumber { get; set; }
        public string MethodOfDecleration { get; set; }

    }
}