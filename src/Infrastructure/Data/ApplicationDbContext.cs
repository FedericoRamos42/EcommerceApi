﻿using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly bool _isTestingEnvironment;
        public DbSet<User>Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool isTestingEnviroment = false) : base(options)
        {
            _isTestingEnvironment =  isTestingEnviroment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");

            var UserType = new EnumToStringConverter<Role>();
            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .HasConversion(UserType);

            var UserStatus = new EnumToStringConverter<Status>();
            modelBuilder.Entity<User>()
                .Property(e => e.Status)
                .HasConversion(UserStatus);

            var ProductStatus = new EnumToStringConverter<Status>();
            modelBuilder.Entity<Product>()
                .Property(e => e.Status)
                .HasConversion(ProductStatus);

            var OrderStatus = new EnumToStringConverter<StatusOrder>();
            modelBuilder.Entity<Order>()
                .Property(e => e.StatusOrder)
                .HasConversion(OrderStatus);

            modelBuilder.Entity<Order>()
                .HasOne(s => s.User)
                .WithMany(u => u.OrdersList);
  
            modelBuilder.Entity<OrderDetail>()
                .HasOne(sd => sd.Order) 
                .WithMany(s => s.Details);


            modelBuilder.Entity<OrderDetail>()
                .HasOne(sd => sd.Product)
                .WithMany(p => p.OrderDetailsList);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category) 
            .WithMany(c => c.Products)
            .IsRequired();

            modelBuilder.Entity<Order>()
           .HasOne(o => o.Payment)
           .WithOne(p => p.Order)
           .HasForeignKey<Payment>(p => p.OrderId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
