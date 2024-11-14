namespace Forum.API.Contracts;

public record PostResponse (
    Guid Id,
    string Title,
    string Description,
    DateTime CreatedAt
    );