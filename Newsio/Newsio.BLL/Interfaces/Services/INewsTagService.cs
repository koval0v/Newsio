using Newsio.BLL.Dtos;

namespace Newsio.BLL.Interfaces.Services
{
    public interface INewsTagService : IBaseService<NewsTagDto>
    {
        Task DeleteByNewsAndTagId(SearchNewsTagDto model);
    }
}
