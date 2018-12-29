using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ItemTemplateCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}