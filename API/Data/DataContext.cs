using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Calculator> Calculators { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Item> Items { get; set; }    
        public DbSet<ItemProperty> ItemProperties { get; set; }            
        public DbSet<ItemTemplate> ItemTemplates { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Project> Projects { get; set; }         
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }  
        public DbSet<Value> Values { get; set; }              
    }
}