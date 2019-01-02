using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ItemTemplateCategory
    {
        public ItemTemplateCategory(int id, string name) {
            this.Id = id;
            this.Name = name;
        }
        
        public ItemTemplateCategory(string name) {
            this.Name = name;
            
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}