using Newsio.BLL.Dtos;

namespace Newsio.BLL.Interfaces.Services
{
    public interface IUserService : IBaseService<UserDto>
    {
        Task<UserDto> GetByLoginAndPasswordAsync(UserLoginDto model);
        Task<bool> UserNameExists(string userName);
        Task<bool> UpdatePasswordAsync(int id, UserChangePasswordDto model);
    }
}
