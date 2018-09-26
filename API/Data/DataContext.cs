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
        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<Item> Items { get; set; }    
        public DbSet<ItemPropertyName> ItemPropertyNames { get; set; }     
        public DbSet<ItemPropertyDescription> ItemPropertyDescriptions { get; set; }     
        public DbSet<ItemTemplate> ItemTemplates { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Project> Projects { get; set; }         
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }  
        public DbSet<Value> Values { get; set; }
        public DbSet<TemplatePropertyRelation> TemplatePropertyRelations { get; set; }
        public DbSet<ItemTemplatePart> ItemTemplateParts { get; set; }      
        public DbSet<ItemItemRelation> ItemItemRelations { get; set; }
        public DbSet<FileData> FileData { get; set; }
        public DbSet<TemplateFileName> TemplateFileNames { get; set; }      

        /************************************************************
        * Overriding the OnModelCreating method allows us to create *
        * one to many and many to many reations in Entity Framework *            
        ************************************************************/
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<TemplatePropertyRelation>()
                .HasKey(t => new { t.TemplateId, t.PropertyId });    

            modelBuilder.Entity<TemplatePropertyRelation>()
                .HasOne(t => t.Template)
                .WithMany(tp => tp.TemplateProperties)
                .HasForeignKey(ti => ti.TemplateId);

            modelBuilder.Entity<TemplatePropertyRelation>()
                .HasOne(t => t.Property)
                .WithMany(p => p.TemplateProperties)
                .HasForeignKey(pi => pi.PropertyId);

            modelBuilder.Entity<ItemTemplatePart>()
                .HasKey(t => new{ t.TemplateId, t.PartId });
            
            modelBuilder.Entity<ItemTemplatePart>()
                .HasOne(t => t.Template)
                .WithMany(p => p.Parts)
                .HasForeignKey(ti => ti.TemplateId);
                
            modelBuilder.Entity<ItemTemplatePart>()
                .HasOne(p => p.Part)
                .WithMany(t => t.PartOf)
                .HasForeignKey(pi => pi.PartId);

            modelBuilder.Entity<Item>()
                .HasMany(x => x.Properties)
                .WithOne(x => x.Item);
        
            modelBuilder.Entity<ItemItemRelation>()
                .HasKey(i => new{ i.ItemId, i.PartId});
            
            modelBuilder.Entity<ItemItemRelation>()
                .HasOne(i => i.Item)
                .WithMany(p => p.Parts)
                .HasForeignKey(x => x.ItemId);

            modelBuilder.Entity<ItemItemRelation>()
                .HasOne(p => p.Part)
                .WithMany(i => i.PartOf)
                .HasForeignKey(ii => ii.PartId);
            

            /* Ensures that IsActive defaults to true */
            modelBuilder.Entity<Item>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);
            
            modelBuilder.Entity<ItemTemplate>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);
            
            modelBuilder.Entity<User>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);
        }
    }
}