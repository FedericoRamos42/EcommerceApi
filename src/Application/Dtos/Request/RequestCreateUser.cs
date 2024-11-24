using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using MediaBrowser.Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Request
{
    public class RequestCreateUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public Role Role { get; set; }

        public static User ToEntity(RequestCreateUser userDto)
        {
            User user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                Password = userDto.Password,
                Role = userDto.Role,
            };

            return user;
        }

    }
}
