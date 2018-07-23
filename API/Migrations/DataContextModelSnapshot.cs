﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Models.Calculator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("Calculators");
                });

            modelBuilder.Entity("API.Models.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

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

                    b.Property<string>("Name")
                        .IsRequired();

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

                    b.Property<int>("CustomerTypeId");

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

                    b.HasKey("Id");

                    b.ToTable("EventLogs");
                });

            modelBuilder.Entity("API.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int?>("CreatedById");

                    b.Property<bool>("IsArchived");

                    b.Property<int?>("ItemId");

                    b.Property<int?>("OrderId");

                    b.Property<string>("Placement");

                    b.Property<int?>("ProjectId");

                    b.Property<int>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TemplateId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("API.Models.ItemPropertyDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("ItemId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

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

                    b.Property<string>("Description");

                    b.Property<string>("Files");

                    b.Property<string>("Name");

                    b.Property<int>("UnitType");

                    b.HasKey("Id");

                    b.ToTable("ItemTemplates");
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

                    b.Property<string>("Company")
                        .IsRequired();

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<int>("Height");

                    b.Property<string>("InvoicePath");

                    b.Property<int>("Length");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderedById");

                    b.Property<int>("PurchaseNumber");

                    b.Property<int>("UnitType");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("OrderedById");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CalculatorId");

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

                    b.Property<int>("Status");

                    b.Property<int>("UnitType");

                    b.Property<string>("Usage");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("CalculatorId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("API.Models.TemplateProperty", b =>
                {
                    b.Property<int>("TemplateId");

                    b.Property<int>("PropertyId");

                    b.HasKey("TemplateId", "PropertyId");

                    b.HasIndex("PropertyId");

                    b.ToTable("TemplateProperties");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Birthdate");

                    b.Property<int?>("CalendarEventId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("Phone");

                    b.Property<int?>("RoleId");

                    b.Property<string>("Surname");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("CalendarEventId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("API.Models.CalendarEvent", b =>
                {
                    b.HasOne("API.Models.Calendar")
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
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Models.Item", b =>
                {
                    b.HasOne("API.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("API.Models.Item")
                        .WithMany("Parts")
                        .HasForeignKey("ItemId");

                    b.HasOne("API.Models.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("API.Models.Project")
                        .WithMany("Products")
                        .HasForeignKey("ProjectId");

                    b.HasOne("API.Models.ItemTemplate", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Models.ItemPropertyDescription", b =>
                {
                    b.HasOne("API.Models.Item")
                        .WithMany("Properties")
                        .HasForeignKey("ItemId");
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
                    b.HasOne("API.Models.User", "OrderedBy")
                        .WithMany()
                        .HasForeignKey("OrderedById")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Models.Project", b =>
                {
                    b.HasOne("API.Models.Calculator", "Calculator")
                        .WithMany()
                        .HasForeignKey("CalculatorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Models.TemplateProperty", b =>
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

                    b.HasOne("API.Models.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
