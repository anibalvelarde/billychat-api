using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Exceptions;
using BillyChat.API.Domain.Services;
using BillyChat.API.Domain.Repositories;
using System.Linq;

namespace BillyChat.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        async Task<User> IUserService.Create(string name, string phone, string email)
        {
            if (!await IsUnique(phone, email)) throw new DuplicateResourceException();
            {
                var newUser = await _userRepository.Create(name, phone, email);
                return newUser;
            }
        }

        async Task<User> IUserService.GetUserById(int id)
        {
            var users = await _userRepository.ListAsync();
            return users
                .Where(u => u.Id.Equals(id))
                .FirstOrDefault();
        }

        async Task<IEnumerable<User>> IUserService.ListAsync()
        {
            IEnumerable<User> usersData = await _userRepository.ListAsync();
            return usersData;
        }

        async Task<User> IUserService.Update(User userToUpdate)
        {
            var updatedUser = await _userRepository.Update(userToUpdate);
            return updatedUser;
        }

        private async Task<bool> IsUnique(string phone, string email){
            var users = await _userRepository.ListAsync();
            return users
                .Where(u => (u.Email == email || u.Phone == phone))
                .Count()
                .Equals(0);
        }

        Task IUserService.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}