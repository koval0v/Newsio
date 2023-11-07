using Newsio.BLL.Interfaces;

namespace Newsio.BLL.Dtos
{
    public class NewsTagDto : IBaseDto
    {
        public int NewsId { get; set; }
        public int TagId { get; set; }
    }
}
