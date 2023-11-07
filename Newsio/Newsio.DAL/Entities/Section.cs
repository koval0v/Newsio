using Newsio.DAL.Interfaces;

namespace Newsio.DAL.Entities
{
    public class Section : IBaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public IReadOnlyCollection<News> News { get; set; } = new List<News>();
    }
}
