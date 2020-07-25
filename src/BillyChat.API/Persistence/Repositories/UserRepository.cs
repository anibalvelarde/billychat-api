using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Repositories;
using BillyChat.API.Persistence.Contexts;
using System;

namespace BillyChat.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) {}

        async Task<User> IUserRepository.Create(string name, string phone, string email)
        {
            var user = new User() {
                Name = name,
                Phone = phone,
                Email = email,
                Address = "Please add address",
                CreatedOn = DateTime.UtcNow,
                LastAccessDate = DateTime.UtcNow
            };
            var newUser = _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return newUser.Entity;
        }

        Task IUserRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<User>> IUserRepository.ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        async Task<User> IUserRepository.Update(User userToUpdate)
        {
            userToUpdate.LastAccessDate = DateTime.UtcNow;
            var updatedUser = _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
            return updatedUser.Entity;
        }
    }
}