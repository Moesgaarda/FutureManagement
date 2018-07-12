using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; private set; }
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