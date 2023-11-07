using AutoMapper;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces;

namespace Newsio.BLL.Services
{
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;

        public SectionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<SectionDto> AddAsync(SectionDto model)
        {
            var section = _mapper.Map<Section>(model);

            var sectionCreated = await _uow.Sections.AddAsync(section);

            await _uow.SaveChangesAsync();

            return _mapper.Map<SectionDto>(sectionCreated);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _uow.Sections.DeleteByIdAsync(modelId);

            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<SectionDto>> GetAllAsync()
        {
            var sections = await _uow.Sections.GetAllAsync();

            return _mapper.Map<IEnumerable<SectionDto>>(sections);
        }

        public async Task<SectionDto> GetByIdAsync(int id)
        {
            var section = await _uow.Sections.GetByIdAsync(id);

            return _mapper.Map<SectionDto>(section);
        }

        public async Task UpdateAsync(int id, SectionDto model)
        {
            var section = _mapper.Map<Section>(model);

            await Task.Run(() => _uow.Sections.Update(section));

            await _uow.SaveChangesAsync();
        }
    }
}
