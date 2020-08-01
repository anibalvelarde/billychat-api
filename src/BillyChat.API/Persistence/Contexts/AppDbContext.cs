using System;
using Microsoft.EntityFrameworkCore;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set;}

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(30);
            builder.Entity<User>()
                .HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Account>().ToTable("Accounts");
            builder.Entity<Account>().HasKey(a => a.Id);
            builder.Entity<Account>().HasAlternateKey(a => a.AccountNumber);
            builder.Entity<Account>()
                .HasOne( a => a.User);

            var commonUser = MakeCommonUser();
            var customer = MakeRandomUser();
            var commonUserId = commonUser.Id;
            var customerId = customer.Id;

            builder.Entity<User>(u =>
            {
                u.HasData(new User[] {
                    commonUser, customer,
                    MakeRandomUser(), MakeRandomUser(), MakeRandomUser(), MakeRandomUser(),
                    MakeRandomUser(), MakeRandomUser(), MakeRandomUser(), MakeRandomUser(),
                    MakeRandomUser(), MakeRandomUser(), MakeRandomUser()
                });
            });
            builder.Entity<Account>().HasData
            (
                    new {
                        UserId = commonUserId,
                        Id = 100,
                        CreatedOn = DateTime.UtcNow,
                        AccountNumber = Guid.NewGuid().ToString(),
                        Type = AccountType.Admin,
                        LastUpdatedOn = DateTime.UtcNow
                    },
                    new {
                        UserId = commonUserId,
                        Id = 200,
                        CreatedOn = DateTime.UtcNow,
                        AccountNumber = Guid.NewGuid().ToString(),
                        Type = AccountType.Advisor,
                        LastUpdatedOn = DateTime.UtcNow
                    },
                    new {
                        UserId = customerId,
                        Id = 300,
                        CreatedOn = DateTime.UtcNow,
                        AccountNumber = Guid.NewGuid().ToString(),
                        Type = AccountType.Client,
                        LastUpdatedOn = DateTime.UtcNow
                    }
            );
        }

        private static User MakeCommonUser()
        {
            return new User
            {
                Id = 100,  // Id set manually due to in-memory provider
                CreatedOn = DateTime.UtcNow,
                Name = "Becky Sue",
                Address = "123 Main St, Anytown USA 12345",
                Phone = "111-867-5309",
                Email = "beckysue@emaildomain.com"
            };
        }
        private static User MakeRandomUser()
        {
            var random = new Random();
            var id = random.Next(1000, 9999);
            return new User
            {
                Id = id,
                CreatedOn = DateTime.UtcNow.AddMonths(-random.Next(1, 60)),
                Name = $"Random Person-{id}",
                Phone = $"555-123-{id}",
                Email = $"random-{id}@server-{id}.com"
            };
        }
    }
}
