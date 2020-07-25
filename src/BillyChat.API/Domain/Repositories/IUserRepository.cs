using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;

namespace BillyChat.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> Create(string name, string phone, string email);
        Task<User> Update(User userToUpdate);
        Task Delete(int id);
    }
}