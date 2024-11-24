using Application.Dtos.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }
        
        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id) 
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("AllUsers")]
        public IActionResult GetAll() 
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult PostUser(RequestCreateUser request) 
        {
            _userService.CreateUser(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet("ByRole/{role}")]
        public IActionResult SearchByRole(string role) 
        {
            var listUsers = _userService.GetUsersByRol(role);
            return Ok(listUsers);
        }
    }
}
