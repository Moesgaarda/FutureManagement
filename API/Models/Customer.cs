namespace API.Models
{
    public class Customer
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string Company { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}