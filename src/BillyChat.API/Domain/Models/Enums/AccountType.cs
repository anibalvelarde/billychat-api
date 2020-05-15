using System.ComponentModel;

namespace BillyChat.API.Domain.Models.Enums
{
    public enum AccountType {
        [Description("Root")]
        Root = -1,
        [Description("Client")]
        Client = 1,
        [Description("Doctor")]
        Doctor = 2,
        [Description("Tutuor")]
        Tutor = 3,
        [Description("Lawyer")]
        Lawyer = 4    
    }
}