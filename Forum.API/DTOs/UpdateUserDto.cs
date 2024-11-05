namespace Forum.API.DTOs;

public record UpdateUserDto(
    Guid Id, 
    string Nickname, 
    string Email, 
    string Password
    );
