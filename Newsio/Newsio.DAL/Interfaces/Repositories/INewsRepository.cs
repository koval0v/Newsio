using Newsio.DAL.Entities;

namespace Newsio.DAL.Interfaces.Repositories
{
    public interface INewsRepository : IBaseRepository<News>
    {
        Task<IEnumerable<News>> GetByAuthorIdAsync(int authorId);
    }
}
