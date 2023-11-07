using Microsoft.EntityFrameworkCore;
using Newsio.DAL.EF;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces.Repositories;

namespace Newsio.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NewsContext _dbContext;

        public UserRepository(NewsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);

            return entity;
        }

        public async Task<User> DeleteByIdAsync(int id)
        {
            var entity = await _dbContext.Users.FindAsync(id) ?? throw new KeyNotFoundException("User doesn't exist");

            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }

            return entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.Include(p => p.News).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.Include(p => p.News).FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException("User doesn't exist");
        }

        public async Task<User> GetByLoginAndPasswordAsync(string userName, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName &&
              x.Password == password) ?? throw new KeyNotFoundException("User doesn't exist");
        }

        public void Update(User entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> UserNameExists(string userName)
        {
            return await _dbContext.Users.AnyAsync(x => x.UserName == userName);
        }
    }
}
