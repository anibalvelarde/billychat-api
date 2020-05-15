using BillyChat.API.Persistence.Contexts;

namespace BillyChat.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context) => _context = context;
    }
}