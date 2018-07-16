using System;
using System.Collections.Generic;
using API.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class Project{
        public Project(){}
        public Project(Customer customer, DateTime startTime, DateTime endTime, ICollection<Item> products, string deliveryAddress, string deliveryCountry, string comment, int invoiceNumber, Calculator calculator, Status status, int width, int height, int length, UnitType unitType, string usage, int orderNumber, string methodOfDecleration){
            this.Customer = customer;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Products = products;
            this.DeliveryAddress = deliveryAddress;
            this.DeliveryCountry = deliveryCountry;
            this.Comment = comment;
            this.InvoiceNumber = invoiceNumber;
            this.Calculator = calculator;
            this.Status = status;
            this.Width = width;
            this.Height = height;
            this.Length = length;
            this.UnitType = unitType;
            this.Usage = usage;
            this.OrderNumber = orderNumber;
            this.MethodOfDecleration = methodOfDecleration;

        }
        public Project(int id, Customer customer, DateTime startTime, DateTime endTime, ICollection<Item> products, string deliveryAddress, string deliveryCountry, string comment, int invoiceNumber, Calculator calculator, Status status, int width, int height, int length, UnitType unitType, string usage, int orderNumber, string methodOfDecleration)
        {
            this.Id = id;
            this.Customer = customer;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Products = products;
            this.DeliveryAddress = deliveryAddress;
            this.DeliveryCountry = deliveryCountry;
            this.Comment = comment;
            this.InvoiceNumber = invoiceNumber;
            this.Calculator = calculator;
            this.Status = status;
            this.Width = width;
            this.Height = height;
            this.Length = length;
            this.UnitType = unitType;
            this.Usage = usage;
            this.OrderNumber = orderNumber;
            this.MethodOfDecleration = methodOfDecleration;

        }

        private Customer _customer;
        private DateTime _startTime;
        private DateTime _endTime;
        private ICollection<Item> _products;

        [Key]
        public int Id { get; private set; }

        [Required]
        public Customer Customer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        /*{
            get
            {
                return _endTime;
            }
            set
            {
                if (StartTime < value)
                {
                    _endTime = value;
                }
                else
                {
                    throw new NotImplementedException("EndTime validation");
                }
            }
        }*/
        public ICollection<Item> Products { get; set; }
        /*{
            get
            {
                return _products;
            }
            set
            {
                if (value == null)
                {
                    _products = new List<Item>();
                }
                else
                {
                    _products = value;
                }
            }
        }*/
        public string DeliveryAddress { get; set; }
        public string DeliveryCountry { get; set; }
        public string Comment { get; set; }
        public int InvoiceNumber { get; set; }
        [Required]
        public Calculator Calculator { get; set; }
        [Required]
        public Status Status { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        [Required]
        public UnitType UnitType { get; set; }
        public string Usage { get; set; }
        public int OrderNumber { get; set; }
        public string MethodOfDecleration { get; set; }

    }
}