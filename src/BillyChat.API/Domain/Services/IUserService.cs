using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;

namespace BillyChat.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> Create(string name, string phone, string email);
        Task<User> Update(User userToUpdate);
        Task<User> GetUserById(int id);
        Task Delete(int id);
    }
}