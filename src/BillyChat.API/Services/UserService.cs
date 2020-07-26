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

        async Task<User> IUserService.CreateAsync(string name, string phone, string email)
        {
            if (!IsValid(name, email, phone)) throw new ApplicationException();
            if (!await IsUnique(phone, email)) throw new DuplicateResourceException();
            var newUser = await _userRepository.CreateAsync(name, phone, email);
            return newUser;
        }

        async Task<User> IUserService.GetUserByIdAnsync(int id)
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

        async Task<User> IUserService.UpdateAsync(User userToUpdate, User currentUser)
        {
            if (currentUser == null) throw new InvalidOperationException();
            if (!IsValid(userToUpdate)) throw new ApplicationException();
            if (userToUpdate.Email != currentUser.Email || userToUpdate.Phone != currentUser.Phone)
            {
                if (!await IsUnique(userToUpdate)) throw new DuplicateResourceException();
                var updatedUser = await _userRepository.UpdateAsync(userToUpdate);
                return updatedUser;
            }
            return currentUser;
        }

        private async Task<bool> IsUnique(string phone, string email){
            var existsWithEmail = await _userRepository.ExistsWithEmailAsync(email);
            var existsWithPhone = await _userRepository.ExistsWtihPhoneAsync(phone);

            return !existsWithEmail && !existsWithPhone;
        }

        private async Task<bool> IsUnique(User toVerify)
        {
            var existsWithEmail = await _userRepository.ExistsWithEmailAsync(toVerify);
            var existsWithPhone = await _userRepository.ExistsWtihPhoneAsync(toVerify);

            return !existsWithEmail && !existsWithPhone;
        }

        private bool IsValid(User toValidate)
        {
            return IsValid(toValidate.Name, toValidate.Email, toValidate.Phone);
        }

        private bool IsValid(string name, string email, string phone)
        {
            return !string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(phone);
        }

        async Task IUserService.DeleteAsync(int id)
        {
            IUserService svc = this;
            var userToDelete = await svc.GetUserByIdAnsync(id);
            if (userToDelete == null) throw new InvalidOperationException();
            await _userRepository.DeleteAsync(userToDelete);
        }
    }
}