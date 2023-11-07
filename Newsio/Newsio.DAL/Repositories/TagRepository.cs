using Microsoft.EntityFrameworkCore;
using Newsio.DAL.EF;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces.Repositories;

namespace Newsio.DAL.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly NewsContext _dbContext;

        public TagRepository(NewsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tag> AddAsync(Tag entity)
        {
            await _dbContext.Tags.AddAsync(entity);

            return entity;
        }

        public async Task<Tag> DeleteByIdAsync(int id)
        {
            var entity = await _dbContext.Tags.FindAsync(id) ?? throw new KeyNotFoundException("Tag doesn't exist");

            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }

            return entity;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _dbContext.Tags.ToListAsync();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            return await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException("Tag doesn't exist");
        }

        public void Update(Tag entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
