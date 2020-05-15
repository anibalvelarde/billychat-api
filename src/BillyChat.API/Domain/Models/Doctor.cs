using System;
using System.Collections.Generic;

namespace BillyChat.API.Domain.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Specialties = new List<Specialty>();
        }
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Account AccountInfo { get; set; }
        public IList<Specialty> Specialties { get; set; }
    }
}