﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestCoreApp.Models;

namespace TestCoreApp.Date
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Select Category" },
                new Category() { Id = 2, Name = "Computers" },
                new Category() { Id = 3, Name = "Mobiles" },
                new Category() { Id = 4, Name = "Electric Machines" }
                );


            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "user",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                });


            base.OnModelCreating(modelBuilder);
        }
    }
}
