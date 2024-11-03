namespace Forum.Domain.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RegisterIp { get; init; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
    public List<PostEntity> Posts { get; init; } = new List<PostEntity>();
    public List<CommentEntity> Comments { get; init; } = new List<CommentEntity>();
}
