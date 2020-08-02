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
    /// This governs operations for magagement of www.billychat.com users model.
    /// </summary>
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        public UsersController(IUserService userSvc, IAccountService acctSvc) 
        {
            _userService = userSvc;
            _accountService = acctSvc;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            IEnumerable<User> users = await _userService.ListAsync();
            return users;
        }

        [HttpGet]
        [Route("/api/[controller]/{id}")]
        public async Task<ActionResult<User>> GetUserAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync(string name, string phone, string email)
        {
            try
            {
                return await _userService.CreateAsync(name, phone, email); 
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

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUserAsync(int id, User userToUpdate)
        {
            try
            {
                if (id != userToUpdate.Id) return BadRequest();
                var currentUser = await _userService.GetByIdAsync(id);
                if ( currentUser == null) return NotFound();
                return await _userService.UpdateAsync(userToUpdate, currentUser);
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

        [HttpDelete]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            if(await _userService.GetByIdAsync(id) == null) return NotFound();
            await _userService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("/api/[controller]/{id}/accounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetUserAccounts(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            return user.Accounts;
        }

        [HttpPost]
        [Route("/api/[controller]/{id}/accounts")]
        public async Task<ActionResult<User>> AddUserAccount(int id, AccountType ofType)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user.HasAccountType(ofType)) return user;
                await _accountService.CreateAsync(user, ofType);
                return await _userService.GetByIdAsync(id);
            }
            catch (ApplicationException)
            {
                return NotFound();
            }
        }
    }
}