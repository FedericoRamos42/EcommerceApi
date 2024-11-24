using Application.Dtos;
using Application.Dtos.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task CreateUser(RequestCreateUser request);
        public Task DeleteUser(int id);
        public Task<UserDto> GetUserById(int id);
        public Task<IEnumerable<UserDto>>? GetAllUsers();
        public Task<IEnumerable<UserDto>>? GetUsersByRol(string Role);
    }
}
