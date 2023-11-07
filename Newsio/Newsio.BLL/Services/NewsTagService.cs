using AutoMapper;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces;

namespace Newsio.BLL.Services
{
    public class NewsTagService : INewsTagService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;

        public NewsTagService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<NewsTagDto> AddAsync(NewsTagDto model)
        {
            var newsTag = _mapper.Map<NewsTag>(model);

            var newsTagCreated = await _uow.NewsTags.AddAsync(newsTag);

            await _uow.SaveChangesAsync();

            return _mapper.Map<NewsTagDto>(newsTagCreated);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _uow.NewsTags.DeleteByIdAsync(modelId);

            await _uow.SaveChangesAsync();
        }

        public async Task DeleteByNewsAndTagId(SearchNewsTagDto model)
        {
            await _uow.NewsTags.DeleteByNewsAndTagId(model.NewsId, model.TagId);

            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewsTagDto>> GetAllAsync()
        {
            var newsTags = await _uow.NewsTags.GetAllAsync();

            return _mapper.Map<IEnumerable<NewsTagDto>>(newsTags);
        }

        public async Task<NewsTagDto> GetByIdAsync(int id)
        {
            var newsTag = await _uow.NewsTags.GetByIdAsync(id);

            return _mapper.Map<NewsTagDto>(newsTag);
        }

        public async Task UpdateAsync(int id, NewsTagDto model)
        {
            var newsTag = _mapper.Map<NewsTag>(model);

            await Task.Run(() => _uow.NewsTags.Update(newsTag));

            await _uow.SaveChangesAsync();
        }
    }
}
