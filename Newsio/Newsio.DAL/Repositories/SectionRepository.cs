using Microsoft.EntityFrameworkCore;
using Newsio.DAL.EF;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces.Repositories;

namespace Newsio.DAL.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly NewsContext _dbContext;

        public SectionRepository(NewsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Section> AddAsync(Section entity)
        {
            await _dbContext.Sections.AddAsync(entity);

            return entity;
        }

        public async Task<Section> DeleteByIdAsync(int id)
        {
            var entity = await _dbContext.Sections.FindAsync(id) ?? throw new KeyNotFoundException("Section doesn't exist");

            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }

            return entity;
        }

        public async Task<IEnumerable<Section>> GetAllAsync()
        {
            return await _dbContext.Sections.ToListAsync();
        }

        public async Task<Section> GetByIdAsync(int id)
        {
            return await _dbContext.Sections.FirstOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException("Section doesn't exist");
        }

        public void Update(Section entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
