using System.ComponentModel;

namespace BillyChat.API.Domain.Models.Enums
{
    public enum AccountType {
        [Description("Admin")]
        Root = -1,
        [Description("Client")]
        Client = 1,
        [Description("Advisor")]
        Doctor = 2,
        [Description("NotSet")]
        NotSet = 3    
    }
}