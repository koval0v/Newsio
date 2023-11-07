using Newsio.BLL.Interfaces;

namespace Newsio.BLL.Dtos
{
    public class TagDto : IBaseDto
    {
        public string Title { get; set; } = string.Empty;
    }
}
