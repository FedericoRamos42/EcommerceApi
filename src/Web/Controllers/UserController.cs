using Application.Dtos;
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
        public async Task<ActionResult<UserDto>> GetById(int id) 
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("AllUsers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll() 
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> PostUser(RequestCreateUser request) 
        {
            await _userService.CreateUser(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet("ByRole/{role}")]
        public async Task<ActionResult> SearchByRole(string role) 
        {
            var listUsers = await _userService.GetUsersByRol(role);
            return Ok(listUsers);
        }
    }
}
