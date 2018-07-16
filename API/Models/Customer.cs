using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class Customer{

        public Customer(){}
        public Customer(int id, string city, string country, string email, string name, string primaryPhoneNumber, string secondaryPhoneNumber, string company, CustomerType customerType){
            this.Id = id;
            this.City = city;
            this.Country = country;
            this.Email = email;
            this.Name = name;
            this.PrimaryPhoneNumber = primaryPhoneNumber;
            this.SecondaryPhoneNumber = secondaryPhoneNumber;
            this.Company = company;
            this.CustomerType = customerType;
        }

        public Customer(string city, string country, string email, string name, string primaryPhoneNumber, string secondaryPhoneNumber, string company, CustomerType customerType){
            this.City = city;
            this.Country = country;
            this.Email = email;
            this.Name = name;
            this.PrimaryPhoneNumber = primaryPhoneNumber;
            this.SecondaryPhoneNumber = secondaryPhoneNumber;
            this.Company = company;
            this.CustomerType = customerType;
        }
        
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