using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    /* Uses all the ints to allow the use of ints rather than strings which is
    *  the default. */
    public class DataContext : IdentityDbContext<User, Role, int, 
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
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
        public DbSet<TemplatePropertyRelation> TemplatePropertyRelations { get; set; }
        public DbSet<ItemTemplatePart> ItemTemplateParts { get; set; }      
        public DbSet<ItemItemRelation> ItemItemRelations { get; set; }
        public DbSet<FileData> FileData { get; set; }
        public DbSet<TemplateFileName> TemplateFileNames { get; set; }     
        public DbSet<OrderFileName> OrderFileNames { get; set; } 
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<ItemTemplateCategory> TemplateCategories { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ItemTemplateCategory> ItemTemplateCategories { get; set; }
        public DbSet<RoleCategory> RoleCategories {get; set;}
        public DbSet<RoleCategoryRoleRelation> RoleCategoryRoleRelation { get; set; }
        public DbSet<UserRoleCategoryRelation> UserRoleCategoryRelations { get; set; }

        
        // TODO Could use refactoring to look like userrole.

        /// <summary> Overriding the OnModelCreating method allows us to create 
        /// one to many and many to many relations in Entity Framework
        /// </summary>

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole => {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<RoleCategoryRoleRelation>()
                .HasKey( rr => new { rr.RoleCategoryId, rr.RoleId});

            modelBuilder.Entity<RoleCategoryRoleRelation>()
                .HasOne( rr => rr.RoleCategory)
                .WithMany( rc => rc.RoleCategoryRoleRelations)
                .HasForeignKey( rr => rr.RoleCategoryId);
                
            modelBuilder.Entity<RoleCategoryRoleRelation>()
                .HasOne( rr => rr.Role)
                .WithMany( r => r.RoleCategoryRoleRelations)
                .HasForeignKey( rr => rr.RoleId);

            modelBuilder.Entity<UserRoleCategoryRelation>()
                .HasKey( ur => new {ur.UserId, ur.RoleCategoryId});
            
            modelBuilder.Entity<UserRoleCategoryRelation>()
                .HasOne(ur => ur.RoleCategory)
                .WithMany(rc => rc.UserRoleCategoryRelations)
                .HasForeignKey( ur => ur.RoleCategoryId);
            
            modelBuilder.Entity<UserRoleCategoryRelation>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoleCategoryRelations)
                .HasForeignKey(ur => ur.UserId);

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