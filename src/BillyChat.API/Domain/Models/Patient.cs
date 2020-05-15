using System;
using System.Collections.Generic;

namespace BillyChat.API.Domain.Models
{
    public class Patient
    {
        public Patient()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Family = new List<FamilyMember>();
        }
        public int Id { get; set; }
        public DateTime CreatedOn { get; private set; }
        public Account AccountInfo { get; set; }
        public IList<FamilyMember> Family { get; private set; }
    }
}