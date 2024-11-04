using Forum.API.DTOs;
using Forum.Application.Interfaces.Repositories;
using Forum.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("User information");
        }

        [HttpPost]
        public async Task<User> Create(CreateUserDto createUserDto)
        {
            User userModel = Forum.Application.Models.User.CreateFromDto(createUserDto.Nickname, createUserDto.Email, createUserDto.Password, createUserDto.RegisterIp);
            return await _usersRepository.CreateUser(userModel);
        }
    }
}
