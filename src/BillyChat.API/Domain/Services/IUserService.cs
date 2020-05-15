using System.Collections.Generic;
using System.Threading.Tasks;
using BillyChat.API.Domain.Models;

namespace BillyChat.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
    }
}