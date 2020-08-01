using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Repositories;
using BillyChat.API.Persistence.Contexts;
using System;
using System.Linq;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Persistence.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context) {}

        async Task<Account> IAccountRepository.CreateAsync(User user, AccountType ofType)
        {
            var newAccount = Account
                .CreateAccount(ofType)
                .WithUser(user);
            var newUser = _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();
            return newUser.Entity;
        }

        async Task IAccountRepository.DeleteAsync(Account acctToDelete)
        {
            _context.Accounts.Remove(acctToDelete);
            await _context.SaveChangesAsync();
        }

        async Task<bool> IAccountRepository.ExistsWithUserAsync(User user)
        {
            var accounts = await _context.Accounts.ToListAsync();
            return accounts
                .Where(a => a.User.Equals(user))
                .FirstOrDefault() != null;
        }

        async Task<bool> IAccountRepository.ExistsWithUserIdAsync(int userId)
        {
            var users = await _context.Accounts.ToListAsync();
            return users
                .Where(a => a.User.Id.Equals(userId))
                .FirstOrDefault() != null;
        }

        async Task<bool> IAccountRepository.ExistsWtihAccountNumberAsync(Guid id)
        {
            var accounts = await _context.Accounts.ToListAsync();
            return accounts
                .Where(a => a.AccountNumber.Equals(id.ToString()))
                .FirstOrDefault() != null;
        }

        async Task<IEnumerable<Account>> IAccountRepository.ListAsync()
        {
            return await _context.Accounts.ToListAsync();
        }
    }
}