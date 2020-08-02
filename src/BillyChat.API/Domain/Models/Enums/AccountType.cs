using System.ComponentModel;

namespace BillyChat.API.Domain.Models.Enums
{
    public enum AccountType {
        [Description("NotSet")]
        NotSet = -1,
        [Description("Client")]
        Client = 1,
        [Description("Advisor")]
        Advisor = 2,
        [Description("Admin")]
        Admin = 99    
    }
}