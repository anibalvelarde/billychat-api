using System.ComponentModel;

namespace BillyChat.API.Domain.Models.Enums
{
    public enum Gender {
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female = 2
    }
}