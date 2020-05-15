using System;

namespace BillyChat.API.Domain.Models
{
    public class FamilyMember
    {
        public string Name { get; set; }
        public Enums.Gender Gender { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public int PatientId { get; set; }
    }
}