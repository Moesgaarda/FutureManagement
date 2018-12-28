using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ItemTemplateCategory
    {
        public ItemTemplateCategory(int id, string name, ICollection<ItemTemplate> templates) {
            this.Id = id;
            this.Name = name;
            this.ItemTemplates = templates;
        }
        
        public ItemTemplateCategory(string name, ICollection<ItemTemplate> templates) {
            this.Name = name;
            this.ItemTemplates = templates;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ItemTemplate> ItemTemplates { get; set; }
        
    }
}