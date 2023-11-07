using Newsio.DAL.Entities;

namespace Newsio.DAL.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByLoginAndPasswordAsync(string userName, string password);
        Task<bool> UserNameExists(string userName);
    }
}
