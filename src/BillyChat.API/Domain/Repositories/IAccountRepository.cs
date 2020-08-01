using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;

namespace BillyChat.API.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> ListAsync();
        Task<Account> CreateAsync(Account prospect);
        Task DeleteAsync(Account accountToDelete);
        Task<bool> ExistsWithUserAsync(User user);
        Task<bool> ExistsWithUserIdAsync(int userId);
        Task<bool> ExistsWtihAccountNumberAsync(Guid id);
    }
}