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
        private ICollection<Item> _products;
        
        [Key]
        public int Id { get; private set; }

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
        public ICollection<Item> Products { get; set; }
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