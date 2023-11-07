using Newsio.DAL.Interfaces;

namespace Newsio.DAL.Entities
{
    public class News : IBaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public IReadOnlyCollection<NewsTag> NewsTags { get; set; } = new List<NewsTag>();
        public int AuthorId { get; set; }
        public User Author { get; set; } = null!;
        public int SectionId { get; set; }
        public Section Section { get; set; } = null!;
    }
}
