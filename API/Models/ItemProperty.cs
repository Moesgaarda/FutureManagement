using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class ItemProperty{
        public ItemProperty(){}
        public ItemProperty(int id, string description){
            this.Id = id;
            this.Description = description;
        }
        public ItemProperty(string description){
            this.Description = description;
        }
        
        [Key]
        public int Id { get; private set; }

        public string Description { get; set; }
    }
}