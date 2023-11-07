using Newsio.DAL.Interfaces;

namespace Newsio.DAL.Entities
{
    public class Tag : IBaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public IReadOnlyCollection<NewsTag> NewsTags { get; set; } = new List<NewsTag>();
    }
}
