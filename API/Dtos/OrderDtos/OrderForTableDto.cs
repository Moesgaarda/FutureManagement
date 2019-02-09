using System;

namespace API.Dtos
{
    public class OrderForTableDto
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime OrderDate { get; set;}
    }
}