using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillyChat.API.Controllers
{
    /// <summary>
    /// This governs operations for magagement of www.billychat.com accounts model.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountsServcie;

        public AccountsController(IAccountService acctSvc) => _accountsServcie = acctSvc;

        [HttpGet]
        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            IEnumerable<Account> accounts = await _accountsServcie.ListAsync();
            return accounts;
        }
    }
}