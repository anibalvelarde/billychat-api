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
    /// This governs operations for users who request to sign-up to www.billychat.com model.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]")]
    public class SignupController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public SignupController(IUserService userSvc, IAccountService accountSvc) 
        {
            _userService = userSvc;
            _accountService = accountSvc;
        }

        [HttpPost]
        [Route("/api/[controller]/client")]
        public async Task<ActionResult<User>> CreateClientUserAsync(string name, string phone, string email)
        {
            try
            {
                var newUser =  await _userService.CreateAsync(name, phone, email); 
                await _accountService.CreateAsync(newUser, AccountType.Client);
                return await _userService.GetByIdAsync(newUser.Id);
            }
            catch (BillyChat.API.Domain.Exceptions.DuplicateResourceException)
            {
                return Conflict();
            }
            catch (System.ApplicationException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/api/[controller]/advisor")]
        public async Task<ActionResult<User>> CreateAdvisorUserAsync(string name, string phone, string email)
        {
            try
            {
                var newUser = await _userService.CreateAsync(name, phone, email);
                await _accountService.CreateAsync(newUser, AccountType.Advisor);
                return await _userService.GetByIdAsync(newUser.Id);
            }
            catch (BillyChat.API.Domain.Exceptions.DuplicateResourceException)
            {
                return Conflict();
            }
            catch (System.ApplicationException)
            {
                return BadRequest();
            }
        }
    }
}