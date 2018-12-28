using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class OrderStatus : Status
    {
        public ICollection<Order> Orders { get; set; }
    }
}