using System;
using Microsoft.EntityFrameworkCore;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            // builder.Entity<User>().HasMany(p => p.Products).WithOne(p => p.User).HasForeignKey(p => p.UserId);

            builder.Entity<User>().HasData
            (
                new User {
                    Id = 100,  // Id set manually due to in-memory provider
                    CreatedOn = DateTime.UtcNow,
                    Name = "Becky Sue",
                    Address = "123 Main St, Anytown USA 12345",
                    Phone = "111-867-5309",
                    Email = "beckysue@emaildomain.com"
                },
                new User {
                    Id = 101,  // Id set manually due to in-memory provider
                    CreatedOn = DateTime.UtcNow,
                    Name = "Constantina Herrera",
                    Address = "456 Downtown Ln, Anytown USA 12345",
                    Phone = "111-867-5309",
                    Email = "sherrera@someemail.com"
                },
                new User {
                    Id = 102,  // Id set manually due to in-memory provider
                    CreatedOn = DateTime.UtcNow,
                    Name = "Alcibiades Pineda",
                    Address = "321 Roadway Blvd, Anytown USA 12345",
                    Phone = "111-867-5309",
                    Email = "sherrera@someemail.com"
                }
            );
        }
    }
}
