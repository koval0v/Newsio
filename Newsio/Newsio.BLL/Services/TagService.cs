using AutoMapper;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces;

namespace Newsio.BLL.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;

        public TagService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<TagDto> AddAsync(TagDto model)
        {
            var tag = _mapper.Map<Tag>(model);

            var tagCreated = await _uow.Tags.AddAsync(tag);

            await _uow.SaveChangesAsync();

            return _mapper.Map<TagDto>(tagCreated);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _uow.Tags.DeleteByIdAsync(modelId);

            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<TagDto>> GetAllAsync()
        {
            var tags = await _uow.Tags.GetAllAsync();

            return _mapper.Map<IEnumerable<TagDto>>(tags);
        }

        public async Task<TagDto> GetByIdAsync(int id)
        {
            var tag = await _uow.Tags.GetByIdAsync(id);

            return _mapper.Map<TagDto>(tag);
        }

        public async Task UpdateAsync(int id, TagDto model)
        {
            var tag = _mapper.Map<Tag>(model);

            await Task.Run(() => _uow.Tags.Update(tag));

            await _uow.SaveChangesAsync();
        }
    }
}
