using System.ComponentModel;

namespace BillyChat.API.Domain.Models.Enums
{
    public enum AccountType {
        [Description("Admin")]
        Admin = -1,
        [Description("Client")]
        Client = 1,
        [Description("Advisor")]
        Advisor = 2,
        [Description("NotSet")]
        NotSet = 3    
    }
}