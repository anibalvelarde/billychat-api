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
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync(string name, string phone, string email)
        {
            try
            {
                return await _userService.Create(name, phone, email); 
            }
            catch (BillyChat.API.Domain.Exceptions.DuplicateResourceException)
            {
                return Conflict();
            }
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUserAsync(int id, User userToUpdate)
        {
            if (id != userToUpdate.Id) return BadRequest();
            return await _userService.Update(userToUpdate);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            if(await _userService.GetUserById(id) == null) return NotFound();
            await _userService.Delete(id);
            return Ok();
        }
    }
}