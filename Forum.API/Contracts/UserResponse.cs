namespace Forum.API.Contracts;

public record UserResponse (
    Guid Id,
    string Nickname,
    string Email
    );
