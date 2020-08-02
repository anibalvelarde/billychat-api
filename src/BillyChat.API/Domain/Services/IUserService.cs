using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;

namespace BillyChat.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> CreateAsync(string name, string phone, string email);
        Task<User> UpdateAsync(User userToUpdate, User currentUser);
        Task<User> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}