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
        Task CreateUser(RequestCreateUser request);
        Task DeleteUser(int id);
        Task<UserDto> GetUserById(int id);
        Task<IEnumerable<UserDto>>? GetAllUsers();
        Task<IEnumerable<UserDto>>? GetUsersByRol(string Role);
    }
}
