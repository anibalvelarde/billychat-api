using System;
using System.Collections.Generic;
using System.Linq;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public DateTime CreatedOn {get; set;}
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime LastAccessDate { get; set; }
        public List<Account> Accounts {get; set;}

        internal bool HasAccountType(AccountType ofType)
        {
            return this.Accounts.Any(a => a.Type.Equals(ofType));
        }
    }
}