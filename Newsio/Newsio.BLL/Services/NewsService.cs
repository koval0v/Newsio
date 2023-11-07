using AutoMapper;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces;

namespace Newsio.BLL.Services
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;

        public NewsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<NewsDto> AddAsync(NewsDto model)
        {
            var news = _mapper.Map<News>(model);

            var newsCreated = await _uow.News.AddAsync(news);

            await _uow.SaveChangesAsync();

            return _mapper.Map<NewsDto>(newsCreated);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _uow.News.DeleteByIdAsync(modelId);

            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewsDto>> GetAllAsync()
        {
            var news = await _uow.News.GetAllAsync();

            return _mapper.Map<IEnumerable<NewsDto>>(news);
        }

        public async Task<NewsDto> GetByIdAsync(int id)
        {
            var news = await _uow.News.GetByIdAsync(id);

            return _mapper.Map<NewsDto>(news);
        }

        public async Task<IEnumerable<NewsDto>> GetByAuthorIdAsync(int authorId)
        {
            var news = await _uow.News.GetByAuthorIdAsync(authorId);

            return _mapper.Map<IEnumerable<NewsDto>>(news);
        }

        public async Task UpdateAsync(int id, NewsDto model)
        {
            var news = _mapper.Map<News>(model);

            await Task.Run(() => _uow.News.Update(news));

            await _uow.SaveChangesAsync();
        }
    }
}
