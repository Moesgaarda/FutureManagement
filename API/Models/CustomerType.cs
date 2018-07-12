using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CustomerType
    {

        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
    }
}