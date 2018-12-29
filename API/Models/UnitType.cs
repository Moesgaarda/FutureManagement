using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class UnitType
    {
        public UnitType(int id, string name) {
            this.Id = id;
            this.Name = name;
        }

        public UnitType(string name) {
            this.Name = name;
        }
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}