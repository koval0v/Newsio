using Microsoft.EntityFrameworkCore;
using Newsio.DAL.EF;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces.Repositories;

namespace Newsio.DAL.Repositories
{
    public class NewsTagRepository : INewsTagRepository
    {
        private readonly NewsContext _dbContext;

        public NewsTagRepository(NewsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<NewsTag> AddAsync(NewsTag entity)
        {
            await _dbContext.NewsTags.AddAsync(entity);

            return entity;
        }

        public async Task<NewsTag> DeleteByIdAsync(int id)
        {
            var entity = await _dbContext.NewsTags.FindAsync(id) ?? throw new KeyNotFoundException("News tag doesn't exist");

            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }

            return entity;
        }

        public async Task<NewsTag> DeleteByNewsAndTagId(int newsId, int tagId)
        {
            var entity = await _dbContext.NewsTags.FirstOrDefaultAsync(p => p.NewsId == newsId && p.TagId == tagId) ?? throw new KeyNotFoundException("News tag doesn't exist");

            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }

            return entity;
        }

        public async Task<IEnumerable<NewsTag>> GetAllAsync()
        {
            return await _dbContext.NewsTags.Include(x => x.News).Include(x => x.Tag).ToListAsync();
        }

        public async Task<NewsTag> GetByIdAsync(int id)
        {
            return await _dbContext.NewsTags.Include(x => x.News).Include(x => x.Tag).FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException("News tag doesn't exist");
        }

        public void Update(NewsTag entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
