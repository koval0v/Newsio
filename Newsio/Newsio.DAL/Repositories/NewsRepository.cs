using Microsoft.EntityFrameworkCore;
using Newsio.DAL.EF;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces.Repositories;

namespace Newsio.DAL.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsContext _dbContext;

        public NewsRepository(NewsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<News> AddAsync(News entity)
        {
            await _dbContext.News.AddAsync(entity);

            return entity;
        }

        public async Task<News> DeleteByIdAsync(int id)
        {
            var entity = await _dbContext.News.FindAsync(id) ?? throw new KeyNotFoundException("News doesn't exist");

            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }

            return entity;
        }

        public async Task<IEnumerable<News>> GetAllAsync()
        {
            return await _dbContext.News.Include(x => x.Author)
                .Include(x => x.Section)
                .Include(x => x.NewsTags)
                    .ThenInclude(p => p.Tag)
                .ToListAsync();
        }

        public async Task<News> GetByIdAsync(int id)
        {
            return await _dbContext.News.Include(x => x.Author)
                .Include(x => x.Section)
                .Include(x => x.NewsTags)
                    .ThenInclude(p => p.Tag)
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException("News doesn't exist");
        }

        public async Task<IEnumerable<News>> GetByAuthorIdAsync(int authorId)
        {
            return await _dbContext.News.Include(x => x.Author)
                .Include(x => x.Section)
                .Include(x => x.NewsTags)
                    .ThenInclude(p => p.Tag)
                .Where(m => m.AuthorId == authorId)
                .ToListAsync();
        }



        public void Update(News entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
