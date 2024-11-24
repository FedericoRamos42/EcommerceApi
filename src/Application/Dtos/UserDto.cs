using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; }
        public string Status { get; set; }
        //public List<Order> OrdersList { get; set; } = new List<Order>();

        public static UserDto CreateDto(User user)
        {
            UserDto dto = new UserDto()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString(),
                Status = user.Status.ToString(),
            };
            return dto;
        }

        public static IEnumerable<UserDto> CreateList(IEnumerable<User> users)
        {
            List<UserDto> list = new List<UserDto>();
            foreach (User user in users)
            {
                list.Add(CreateDto(user));
            }
            return list;
        }
    }
}
