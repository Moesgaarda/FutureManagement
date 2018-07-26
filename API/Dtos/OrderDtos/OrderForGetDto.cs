using System;

namespace API.Dtos
{
    public class OrderForGetDto
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime OrderDate { get; set;}
    }
}