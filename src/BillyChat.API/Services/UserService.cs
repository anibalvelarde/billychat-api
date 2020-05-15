using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Services;
using BillyChat.API.Domain.Repositories;

namespace BillyChat.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<IEnumerable<User>> ListAsync()
        {
            IEnumerable<User> usersData = await _userRepository.ListAsync();
            return usersData;
        }
    }
}