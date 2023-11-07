using Newsio.BLL.Interfaces;

namespace Newsio.BLL.Dtos
{
    public class NewsDto : IBaseDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int AuthorId { get; set; }
        public int SectionId { get; set; }
        public UserDto? Author { get; set; }
        public SectionDto? Section { get; set; }
        public IReadOnlyCollection<TagDto>? Tags { get; set; } = new List<TagDto>();
    }
}
