using Newsio.DAL.Interfaces;

namespace Newsio.DAL.Entities
{
    public class NewsTag : IBaseEntity
    {
        public int NewsId { get; set; }
        public News News { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}
