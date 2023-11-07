using Newsio.DAL.Entities;

namespace Newsio.DAL.Interfaces.Repositories
{
    public interface INewsTagRepository : IBaseRepository<NewsTag>
    {
        Task<NewsTag> DeleteByNewsAndTagId(int newsId, int tagId);
    }
}
