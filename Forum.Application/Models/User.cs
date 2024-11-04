using Forum.Domain.Entities;

namespace Forum.Application.Models;

public class User
{
    public Guid Id {  get; set; }
    
    public string Nickname { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string RegisterIp { get; init; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; }

    public List<Post> Posts { get; init; } = new List<Post>();

    public List<Comment> Comments { get; init; } = new List<Comment>();

    public static User CreateFromEntity(UserEntity entity)
    {
        return new User()
        {
            Id = entity.Id,
            Nickname = entity.Nickname,
            Email = entity.Email,
            Password = entity.Password,
            RegisterIp = entity.RegisterIp,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }

    public static User CreateFromDto(string nickname, string email, string password, string registerIp) 
    {
        User user = new User()
        {
            Id = Guid.NewGuid(),
            Nickname = nickname,
            Email = email,
            Password = password,
            RegisterIp = registerIp,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        return user;
    }
}
