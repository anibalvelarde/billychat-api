using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Domain.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> ListAsync();
        Task<Account> CreateAsync(User user, AccountType ofType);
        Task<Account> GetByIdAnsync(int id);
        Task DeleteAsync(int id);
    }
}