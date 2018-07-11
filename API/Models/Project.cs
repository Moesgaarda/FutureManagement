using System;
using System.Collections.Generic;
using API.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Project
    {
        private Customer _customer;
        private DateTime _startTime;
        private DateTime _endTime;
        private List<Item> _products;
        
        public int Id { get; }

        [Required]
        public Customer Customer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { 
            get{
                return _endTime;
            }
            set{
                if (StartTime < value){
                    _endTime = value;
                }
                else{
                    throw new NotImplementedException("EndTime validation");
                }
            } 
        }
        public List<Item> Products {
            get{
                return _products;
            } 
            set{
                if (value == null){
                    _products = new List<Item>();
                }
                else{
                    _products = value;
                }
            }}
        public string DeliveryAddress { get; set; }
        public string DeliveryCountry { get; set; }
        public string Comments { get; set; }
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