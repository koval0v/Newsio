using Microsoft.AspNetCore.Mvc;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;

namespace Newsio.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagsService;

        public TagsController(ITagService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDto>>> Get()
        {
            var tags = await _tagsService.GetAllAsync();

            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagDto>> Get(int id)
        {
            var tag = await _tagsService.GetByIdAsync(id);

            return Ok(tag);
        }


        [HttpPost]
        public async Task<ActionResult> Add(TagDto model)
        {
            var created = await _tagsService.AddAsync(model);

            return CreatedAtAction(nameof(Add), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TagDto model)
        {
            await _tagsService.UpdateAsync(id, model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _tagsService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}