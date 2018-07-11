using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CustomerType
    {
        public int Id { get; }
        [Required]
        public string Name { get; set; }
    }
}