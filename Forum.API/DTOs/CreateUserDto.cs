namespace Forum.API.DTOs;

public record CreateUserDto(
    string Nickname, 
    string Email, 
    string Password, 
    string RegisterIp = "127.0.0.1"
    );
