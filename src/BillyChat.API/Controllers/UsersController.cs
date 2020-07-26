using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillyChat.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) => _userService = userService;

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
            var user = await _userService.GetUserByIdAnsync(id);
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
                var currentUser = await _userService.GetUserByIdAnsync(id);
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
            if(await _userService.GetUserByIdAnsync(id) == null) return NotFound();
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}