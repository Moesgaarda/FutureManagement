using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
    }
}