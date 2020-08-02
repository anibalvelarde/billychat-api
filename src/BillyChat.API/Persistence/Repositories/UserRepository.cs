using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Repositories;
using BillyChat.API.Persistence.Contexts;
using System;
using System.Linq;

namespace BillyChat.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) {}

        async Task<User> IUserRepository.CreateAsync(string name, string phone, string email)
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

        async Task IUserRepository.DeleteAsync(User userToDelete)
        {
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        async Task<bool> IUserRepository.ExistsWithEmailAsync(string matchEmail)
        {
            var users = await _context.Users.ToListAsync();
            return users
                .Where(u => u.Email.Equals(matchEmail))
                .FirstOrDefault() != null;
        }

        async Task<bool> IUserRepository.ExistsWithEmailAsync(User toMatchForEmail)
        {
            var users = await _context.Users.ToListAsync();
            return users
                .Where(u => u.Id != toMatchForEmail.Id && u.Email.Equals(toMatchForEmail.Email))
                .FirstOrDefault() != null;
        }

        async Task<bool> IUserRepository.ExistsWtihPhoneAsync(string matchPhone)
        {
            var users = await _context.Users.ToListAsync();
            return users
                .Where(u => u.Phone.Equals(matchPhone))
                .FirstOrDefault() != null;
        }

        async Task<bool> IUserRepository.ExistsWtihPhoneAsync(User toMatchForPhone)
        {
            var users = await _context.Users.ToListAsync();
            return users
                .Where(u => u.Id != toMatchForPhone.Id && u.Email.Equals(toMatchForPhone.Phone))
                .FirstOrDefault() != null;
        }

        async Task<IEnumerable<User>> IUserRepository.ListAsync()
        {
            return await _context.Users
                .Include(u => u.Accounts)
                .ToListAsync();
        }

        async Task<User> IUserRepository.UpdateAsync(User userToUpdate)
        {
            userToUpdate.LastAccessDate = DateTime.UtcNow;
            var updatedUser = _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
            return updatedUser.Entity;
        }
    }
}