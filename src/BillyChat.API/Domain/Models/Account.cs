using System;
using System.Collections.Generic;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Domain.Models
{
    public class Account
    {
        public Account()
        {
            this.Type = AccountType.Root;
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public User UserInfo { get; set; }
        public string AccountNumber { get; set; }
        public AccountType Type { get; private set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}