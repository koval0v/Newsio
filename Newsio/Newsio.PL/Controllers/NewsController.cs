using Microsoft.AspNetCore.Mvc;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;

namespace Newsio.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDto>>> Get()
        {
            var news = await _newsService.GetAllAsync();

            return Ok(news);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDto>> Get(int id)
        {
            var news = await _newsService.GetByIdAsync(id);

            return Ok(news);
        }

        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<NewsDto>> GetByAuthorId(int authorId)
        {
            var news = await _newsService.GetByAuthorIdAsync(authorId);

            return Ok(news);
        }


        [HttpPost]
        public async Task<ActionResult> Add(NewsDto model)
        {
            var created = await _newsService.AddAsync(model);

            return CreatedAtAction(nameof(Add), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, NewsDto model)
        {
            await _newsService.UpdateAsync(id, model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _newsService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}