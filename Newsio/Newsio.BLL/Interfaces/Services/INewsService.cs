using Newsio.BLL.Dtos;

namespace Newsio.BLL.Interfaces.Services
{
    public interface INewsService : IBaseService<NewsDto>
    {
        Task<IEnumerable<NewsDto>> GetByAuthorIdAsync(int authorId);
    }
}
