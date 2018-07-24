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

        public Task<List<Customer>> GetAllCustomers(){
            throw new NotImplementedException();
        }

        public Task<bool> AddNewCustomer(Customer customer){
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomer(int userId){
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomer(int userId){
            throw new NotImplementedException();
        }

        public Task<bool> EditCustomer(Customer customer){
            throw new NotImplementedException();
        }
    }
}