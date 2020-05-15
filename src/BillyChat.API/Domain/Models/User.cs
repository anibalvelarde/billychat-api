using System;

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
    }
}