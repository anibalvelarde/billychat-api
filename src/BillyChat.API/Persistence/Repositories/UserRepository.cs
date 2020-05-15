using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Repositories;
using BillyChat.API.Persistence.Contexts;

namespace BillyChat.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) {}

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}