﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190121203206_AddedCategory")]
    partial class AddedCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Models.Calculator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("Calculators");
                });

            modelBuilder.Entity("API.Models.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("API.Models.CalendarEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CalendarId");

                    b.Property<int?>("CreatedById");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("EventType");

                    b.Property<string>("Name");

                    b.Property<int>("RepeatedInterval");

                    b.Property<bool>("Repeats");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("CreatedById");

                    b.ToTable("CalendarEvents");
                });

            modelBuilder.Entity("API.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Company");

                    b.Property<string>("Country");

                    b.Property<int?>("CustomerTypeId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PrimaryPhoneNumber");

                    b.Property<string>("SecondaryPhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("API.Models.CustomerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CustomerTypes");
                });

            modelBuilder.Entity("API.Models.EventLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("LocalIP");

                    b.Property<DateTime>("Time");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EventLogs");
                });

            modelBuilder.Entity("API.Models.FileData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("FileHash");

                    b.Property<string>("FilePath");

                    b.HasKey("Id");

                    b.ToTable("FileData");
                });

            modelBuilder.Entity("API.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int?>("CreatedById");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<int?>("OrderId");

                    b.Property<string>("Placement");

                    b.Property<int?>("ProjectId");

                    b.Property<int?>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TemplateId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("API.Models.ItemItemRelation", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<int>("PartId");

                    b.Property<int>("Amount");

                    b.HasKey("ItemId", "PartId");

                    b.HasIndex("PartId");

                    b.ToTable("ItemItemRelations");
                });

            modelBuilder.Entity("API.Models.ItemPropertyDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("ItemId");

                    b.Property<int?>("PropertyNameId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PropertyNameId");

                    b.ToTable("ItemPropertyDescriptions");
                });

            modelBuilder.Entity("API.Models.ItemPropertyName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ItemPropertyNames");
                });

            modelBuilder.Entity("API.Models.ItemTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<int>("LowerLimit");

                    b.Property<string>("Name");

                    b.Property<int?>("RevisionedFromId");

                    b.Property<int?>("UnitTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RevisionedFromId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("ItemTemplates");
                });

            modelBuilder.Entity("API.Models.ItemTemplateCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ItemTemplateCategory");
                });

            modelBuilder.Entity("API.Models.ItemTemplatePart", b =>
                {
                    b.Property<int>("TemplateId");

                    b.Property<int>("PartId");

                    b.Property<int>("Amount");

                    b.HasKey("TemplateId", "PartId");

                    b.HasIndex("PartId");

                    b.ToTable("ItemTemplateParts");
                });

            modelBuilder.Entity("API.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AssignedUserId");

                    b.Property<string>("Company");

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<int>("Height");

                    b.Property<bool>("InternalOrder");

                    b.Property<int>("Length");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int?>("OrderedById");

                    b.Property<int>("PurchaseNumber");

                    b.Property<int?>("SignedById");

                    b.Property<int>("Status");

                    b.Property<int?>("UnitTypeId");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("OrderedById");

                    b.HasIndex("SignedById");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API.Models.OrderFileName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FileDataId");

                    b.Property<string>("FileName");

                    b.Property<int?>("OrderId");

                    b.HasKey("Id");

                    b.HasIndex("FileDataId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderFileNames");
                });

            modelBuilder.Entity("API.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CalculatorId");

                    b.Property<string>("Comment");

                    b.Property<int>("CustomerId");

                    b.Property<string>("DeliveryAddress");

                    b.Property<string>("DeliveryCountry");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("Height");

                    b.Property<int>("InvoiceNumber");

                    b.Property<int>("Length");

                    b.Property<string>("MethodOfDecleration");

                    b.Property<int>("OrderNumber");

                    b.Property<DateTime>("StartTime");

                    b.Property<int?>("StatusId");

                    b.Property<int?>("UnitTypeId");

                    b.Property<string>("Usage");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("CalculatorId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("API.Models.ProjectStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProjectStatuses");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("API.Models.TemplateFileName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FileDataId");

                    b.Property<string>("FileName");

                    b.Property<int?>("ItemTemplateId");

                    b.HasKey("Id");

                    b.HasIndex("FileDataId");

                    b.HasIndex("ItemTemplateId");

                    b.ToTable("TemplateFileNames");
                });

            modelBuilder.Entity("API.Models.TemplatePropertyRelation", b =>
                {
                    b.Property<int>("TemplateId");

                    b.Property<int>("PropertyId");

                    b.HasKey("TemplateId", "PropertyId");

                    b.HasIndex("PropertyId");

                    b.ToTable("TemplatePropertyRelations");
                });

            modelBuilder.Entity("API.Models.UnitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UnitTypes");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("Birthdate");

                    b.Property<int?>("CalendarEventId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Surname");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CalendarEventId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("API.Models.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("API.Models.CalendarEvent", b =>
                {
                    b.HasOne("API.Models.Calendar", "Calendar")
                        .WithMany("Events")
                        .HasForeignKey("CalendarId");

                    b.HasOne("API.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("API.Models.Customer", b =>
                {
                    b.HasOne("API.Models.CustomerType", "CustomerType")
                        .WithMany()
                        .HasForeignKey("CustomerTypeId");
                });

            modelBuilder.Entity("API.Models.EventLog", b =>
                {
                    b.HasOne("API.Models.User", "User")
                        .WithMany("Changes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Models.Item", b =>
                {
                    b.HasOne("API.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("API.Models.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("API.Models.Project")
                        .WithMany("Products")
                        .HasForeignKey("ProjectId");

                    b.HasOne("API.Models.ItemTemplate", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId");
                });

            modelBuilder.Entity("API.Models.ItemItemRelation", b =>
                {
                    b.HasOne("API.Models.Item", "Item")
                        .WithMany("Parts")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Models.Item", "Part")
                        .WithMany("PartOf")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Models.ItemPropertyDescription", b =>
                {
                    b.HasOne("API.Models.Item", "Item")
                        .WithMany("Properties")
                        .HasForeignKey("ItemId");

                    b.HasOne("API.Models.ItemPropertyName", "PropertyName")
                        .WithMany()
                        .HasForeignKey("PropertyNameId");
                });

            modelBuilder.Entity("API.Models.ItemTemplate", b =>
                {
                    b.HasOne("API.Models.ItemTemplateCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("API.Models.ItemTemplate", "RevisionedFrom")
                        .WithMany()
                        .HasForeignKey("RevisionedFromId");

                    b.HasOne("API.Models.UnitType", "UnitType")
                        .WithMany()
                        .HasForeignKey("UnitTypeId");
                });

            modelBuilder.Entity("API.Models.ItemTemplatePart", b =>
                {
                    b.HasOne("API.Models.ItemTemplate", "Part")
                        .WithMany("PartOf")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Models.ItemTemplate", "Template")
                        .WithMany("Parts")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Models.Order", b =>
                {
                    b.HasOne("API.Models.User", "AssignedUser")
                        .WithMany()
                        .HasForeignKey("AssignedUserId");

                    b.HasOne("API.Models.User", "OrderedBy")
                        .WithMany()
                        .HasForeignKey("OrderedById");

                    b.HasOne("API.Models.User", "SignedBy")
                        .WithMany()
                        .HasForeignKey("SignedById");

                    b.HasOne("API.Models.UnitType", "UnitType")
                        .WithMany()
                        .HasForeignKey("UnitTypeId");
                });

            modelBuilder.Entity("API.Models.OrderFileName", b =>
                {
                    b.HasOne("API.Models.FileData", "FileData")
                        .WithMany()
                        .HasForeignKey("FileDataId");

                    b.HasOne("API.Models.Order", "Order")
                        .WithMany("Files")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("API.Models.Project", b =>
                {
                    b.HasOne("API.Models.Calculator", "Calculator")
                        .WithMany()
                        .HasForeignKey("CalculatorId");

                    b.HasOne("API.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Models.ProjectStatus", "Status")
                        .WithMany("Projects")
                        .HasForeignKey("StatusId");

                    b.HasOne("API.Models.UnitType", "UnitType")
                        .WithMany()
                        .HasForeignKey("UnitTypeId");
                });

            modelBuilder.Entity("API.Models.TemplateFileName", b =>
                {
                    b.HasOne("API.Models.FileData", "FileData")
                        .WithMany()
                        .HasForeignKey("FileDataId");

                    b.HasOne("API.Models.ItemTemplate", "ItemTemplate")
                        .WithMany("Files")
                        .HasForeignKey("ItemTemplateId");
                });

            modelBuilder.Entity("API.Models.TemplatePropertyRelation", b =>
                {
                    b.HasOne("API.Models.ItemPropertyName", "Property")
                        .WithMany("TemplateProperties")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Models.ItemTemplate", "Template")
                        .WithMany("TemplateProperties")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.HasOne("API.Models.CalendarEvent")
                        .WithMany("Participants")
                        .HasForeignKey("CalendarEventId");
                });

            modelBuilder.Entity("API.Models.UserRole", b =>
                {
                    b.HasOne("API.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("API.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("API.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("API.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("API.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}