using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BillyChat.API.Domain.Models.Enums;

[assembly: InternalsVisibleToAttribute("BillyChat.Api.Tests")]
namespace BillyChat.API.Domain.Models
{
    public class Account
    {
        internal static Account CreateAccount(AccountType type)
        {
            var newAccount = new Account();
            newAccount.Type = type;
            newAccount.LastUpdatedOn = DateTime.UtcNow;
            newAccount.AccountNumber = Guid.NewGuid().ToString();
            return newAccount;
        }

        internal Account WithUser(User user)
        {
            var updated = Account.CreateAccount(this.Type);
            updated.Id = user.Id;
            updated.User = user;
            updated.LastUpdatedOn = DateTime.UtcNow;
            return updated;
        }

        public Account()
        {
            this.Type = AccountType.NotSet;
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public User User { get; set; }
        public string AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public bool IsValid()
        {
            return
                this.Type != AccountType.NotSet &&
                this.User != null;
        }
    }
}