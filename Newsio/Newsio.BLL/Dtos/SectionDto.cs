using Newsio.BLL.Interfaces;

namespace Newsio.BLL.Dtos
{
    public class SectionDto : IBaseDto
    {
        public string Title { get; set; } = string.Empty;
    }
}
