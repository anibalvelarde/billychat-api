using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;

namespace BillyChat.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
    }
}