using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Exceptions;
using BillyChat.API.Domain.Services;
using BillyChat.API.Domain.Repositories;
using System.Linq;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository acctRepo) => _accountRepository = acctRepo;

        async Task<Account> IAccountService.CreateAsync(User user, AccountType ofType)
        {
            if (user is null) throw new ApplicationException();
            var newProspect = Account
                .CreateAccount(ofType)
                .WithUser(user);
            var newAccount = await _accountRepository.CreateAsync(newProspect);
            return newAccount;
        }

        async Task<Account> IAccountService.GetByIdAnsync(int id)
        {
            var accounts = await _accountRepository.ListAsync();
            return accounts
                .Where(acc => acc.UserId.Equals(id))
                .FirstOrDefault();
        }

        async Task<IEnumerable<Account>> IAccountService.ListAsync()
        {
            IEnumerable<Account> accountsData = await _accountRepository.ListAsync();
            return accountsData;
        }

        async Task IAccountService.DeleteAsync(int id)
        {
            IAccountService svc = this;
            var acctToDelete = await svc.GetByIdAnsync(id);
            if (acctToDelete == null) throw new InvalidOperationException();
            await _accountRepository.DeleteAsync(acctToDelete);
        }
    }
}