using Application.Dtos;
using Application.Dtos.Request;
using Application.Interfaces;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;


namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(RequestCreateUser request)
        {
            if (request == null) throw new NotFoundException("Request is null");

            if (!Enum.IsDefined(typeof(Role), request.Role))
            {
                throw new NotFoundException($"Invalid role: {request.Role}");
            }
            var user = RequestCreateUser.ToEntity(request);
            await _userRepository.Create(user);
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                throw new NotFoundException($"The user with id {id} does not exist");
            }
            await _userRepository.Delete(user);
        }

        public async Task<IEnumerable<UserDto>>? GetAllUsers()
        {
            var listUser = await _userRepository.GetAll();
            return UserDto.CreateList(listUser);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                throw new NotFoundException($"The user with id {id} does not exist");
            }
            return UserDto.CreateDto(user);
        }

        public async Task<IEnumerable<UserDto>>? GetUsersByRol(string Role)
        {
            var list =  await _userRepository.Search(u=> u.Role.ToString() == Role);
            return UserDto.CreateList(list);
        }
    }
}
