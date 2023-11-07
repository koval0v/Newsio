using Newsio.BLL.Interfaces;
using Newsio.DAL.Entities;

namespace Newsio.BLL.Dtos
{
    public class UserDto : IBaseDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
