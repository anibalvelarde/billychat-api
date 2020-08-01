using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;

namespace BillyChat.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> CreateAsync(string name, string phone, string email);
        Task<User> UpdateAsync(User userToUpdate);
        Task DeleteAsync(User userToDelete);
        Task<bool> ExistsWithEmailAsync(string matchEmail);
        Task<bool> ExistsWtihPhoneAsync(string matchPhone);
        Task<bool> ExistsWithEmailAsync(User toMatchEmail);
        Task<bool> ExistsWtihPhoneAsync(User toMatchPhone);
    }
}