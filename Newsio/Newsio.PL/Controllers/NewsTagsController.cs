using Microsoft.AspNetCore.Mvc;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;

namespace Newsio.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsTagsController : ControllerBase
    {
        private readonly INewsTagService _newsTagsService;

        public NewsTagsController(INewsTagService newsTagsService)
        {
            _newsTagsService = newsTagsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsTagDto>>> Get()
        {
            var newsTags = await _newsTagsService.GetAllAsync();

            return Ok(newsTags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsTagDto>> Get(int id)
        {
            var newsTag = await _newsTagsService.GetByIdAsync(id);

            return Ok(newsTag);
        }


        [HttpPost]
        public async Task<ActionResult> Add(NewsTagDto model)
        {
            var created = await _newsTagsService.AddAsync(model);

            return CreatedAtAction(nameof(Add), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, NewsTagDto model)
        {
            await _newsTagsService.UpdateAsync(id, model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _newsTagsService.DeleteByIdAsync(id);

            return NoContent();
        }


        [HttpPost("deleteByIds")]
        public async Task<ActionResult> DeleteByNewsAndTagId(SearchNewsTagDto model)
        {
            await _newsTagsService.DeleteByNewsAndTagId(model);

            return NoContent();
        }
    }
}