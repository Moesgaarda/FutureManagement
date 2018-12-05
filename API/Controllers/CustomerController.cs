using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers{
    [Route("api/[controller]")]
    public class CustomerController : Controller{
        private readonly DataContext _context;

        public CustomerController(DataContext context){
            _context = context;
        }

        [Authorize(Policy = "Customer_View")]
        public Task<List<Customer>> GetAllCustomers(){
            throw new NotImplementedException();
        }

        [Authorize(Policy = "Customer_Add")]
        public Task<bool> AddNewCustomer(Customer customer){
            throw new NotImplementedException();
        }

        [Authorize(Policy = "Customer_View")]
        public Task<Customer> GetCustomer(int userId){
            throw new NotImplementedException();
        }

        // TODO: Kan man delete? Skal man ikke aktivere/deaktivere?
        [Authorize(Policy = "Customer_ActivateDeactivate")] 
        public Task<bool> DeleteCustomer(int userId){
            throw new NotImplementedException();
        }

        [Authorize(Policy = "Customer_Edit")]
        public Task<bool> EditCustomer(Customer customer){
            throw new NotImplementedException();
        }
    }
}