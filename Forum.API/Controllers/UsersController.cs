using Forum.API.DTOs;
using Forum.API.Contracts;
using Forum.Application.Interfaces.Repositories;
using Forum.Application.Interfaces.Services;
using Forum.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
    {
        IEnumerable<User> users = await _usersService.GetAllUsers();
        IEnumerable<UserResponse> response = users.Select(u => new UserResponse(u.Id, u.Nickname, u.Email));
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUserById(Guid id)
    {
        try
        {
            User user = await _usersService.GetUserById(id);
            UserResponse response = new UserResponse(user.Id, user.Nickname, user.Email);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            User userModel = Forum.Application.Models.User.CreateFromDto(
            createUserDto.Nickname,
            createUserDto.Email,
            createUserDto.Password,
            createUserDto.RegisterIp
            );
            User user = await _usersService.CreateUser(userModel);
            UserResponse response = new UserResponse(user.Id, user.Nickname, user.Email);
            return Ok(response);
        }
        catch(Exception ex) 
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<UserResponse>> UpdateUser(UpdateUserDto updateUserDto)
    {
        try
        {
            User userModel = await _usersService.GetUserById(updateUserDto.Id);
            userModel.Nickname = updateUserDto.Nickname ?? userModel.Nickname;
            userModel.Email = updateUserDto.Email ?? userModel.Email;
            userModel.Password = updateUserDto.Password ?? userModel.Password;

            User userUpdate = await _usersService.CreateUser(userModel);
            UserResponse response = new UserResponse(userUpdate.Id, userUpdate.Nickname, userUpdate.Email);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}