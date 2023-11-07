using AutoMapper;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;
using Newsio.DAL.Entities;
using Newsio.DAL.Interfaces;

namespace Newsio.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<UserDto> AddAsync(UserDto model)
        {
            var user = _mapper.Map<User>(model);

            var userCreated = await _uow.Users.AddAsync(user);

            await _uow.SaveChangesAsync();

            return _mapper.Map<UserDto>(userCreated);
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            await _uow.Users.DeleteByIdAsync(modelId);

            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _uow.Users.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _uow.Users.GetByIdAsync(id);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByLoginAndPasswordAsync(UserLoginDto model)
        {
            var userAuth = await _uow.Users.GetByLoginAndPasswordAsync(model.UserName, model.Password);

            return _mapper.Map<UserDto>(userAuth);
        }

        public async Task<bool> UserNameExists(string userName)
        { 
            return await _uow.Users.UserNameExists(userName);
        }

        public async Task UpdateAsync(int id, UserDto model)
        {
            var user = _mapper.Map<User>(model);

            await Task.Run(() => _uow.Users.Update(user));

            await _uow.SaveChangesAsync();
        }

        public async Task<bool> UpdatePasswordAsync(int id, UserChangePasswordDto model)
        {   
            if (PreviousPasswordIsCorrect(id, model.PreviousPassword).Result)
            {
                var user = await _uow.Users.GetByIdAsync(id);
                user.Password = model.NewPassword;

                await _uow.SaveChangesAsync();
                return true;
            } else
            {
                return false;
            }
        }

        private async Task<bool> PreviousPasswordIsCorrect(int id, string previous)
        {
            var user = await _uow.Users.GetByIdAsync(id);

            return user.Password == previous;
        }
    }
}
