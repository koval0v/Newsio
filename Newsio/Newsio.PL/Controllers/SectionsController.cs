using Microsoft.AspNetCore.Mvc;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;

namespace Newsio.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionService _sectionsService;

        public SectionsController(ISectionService sectionsService)
        {
            _sectionsService = sectionsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectionDto>>> Get()
        {
            var sections = await _sectionsService.GetAllAsync();

            return Ok(sections);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SectionDto>> Get(int id)
        {
            var section = await _sectionsService.GetByIdAsync(id);

            return Ok(section);
        }


        [HttpPost]
        public async Task<ActionResult> Add(SectionDto model)
        {
            var created = await _sectionsService.AddAsync(model);

            return CreatedAtAction(nameof(Add), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, SectionDto model)
        {
            await _sectionsService.UpdateAsync(id, model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _sectionsService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}