using Newsio.DAL.Interfaces;

namespace Newsio.DAL.Entities
{
    public class User : IBaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public IReadOnlyCollection<News> News { get; set; } = new List<News>();
    }
}
