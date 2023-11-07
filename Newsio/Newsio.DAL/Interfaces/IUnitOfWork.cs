using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces.Repositories;

namespace Newsio.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        INewsRepository News { get; }
        INewsTagRepository NewsTags { get; }
        IBaseRepository<Section> Sections { get; }
        IBaseRepository<Tag> Tags { get; }
        IUserRepository Users { get; }
        Task SaveChangesAsync();
    }
}
