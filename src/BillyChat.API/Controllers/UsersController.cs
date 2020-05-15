using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            IEnumerable<User> users = await _userService.ListAsync();
            return users;
        }
    }
}