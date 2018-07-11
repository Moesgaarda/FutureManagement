using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Customer
    {
        public int Id { get; } 
        public string City { get; set; }
        public string Country { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        [Phone]
        public string PrimaryPhoneNumber { get; set; }
        [Phone]
        public string SecondaryPhoneNumber { get; set; }
        public string Company { get; set; }

        [Required]
        public CustomerType CustomerType { get; set; }
    }
}