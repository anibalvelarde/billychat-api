using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Models.Enums;
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
        private readonly IUserService _userService;

        public AccountsController(IAccountService acctSvc, IUserService userSvcv) 
        { 
            _accountsServcie = acctSvc;
            _userService = userSvcv;
        }

        [HttpGet]
        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            IEnumerable<Account> accounts = await _accountsServcie.ListAsync();
            return accounts;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccountAsync(int userId, AccountType ofType)
        {
            try
            {
                var aUser = await _userService.GetByIdAsync(userId);
                if (!aUser.HasAccountType(ofType))
                {
                    await _accountsServcie.CreateAsync(
                        aUser,
                        ofType
                    );
                }
                return Ok();
            }
            catch (ApplicationException)
            {
                return NotFound();
            }
        }
    }
}