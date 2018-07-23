using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class ItemPropertyName{
        public ItemPropertyName(){}

        public ItemPropertyName(string name){
            this.Name = name;
        }

        public ItemPropertyName(int id, string name){
            this.Id = id;
            this.Name = name;
            this.TemplateProperties = new HashSet<TemplateProperty>();
        }
        
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<TemplateProperty> TemplateProperties{ get; set; }
    }
}