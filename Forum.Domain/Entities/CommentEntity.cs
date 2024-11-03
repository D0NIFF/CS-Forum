using System.Text.Json;

namespace Forum.Domain.Entities;

public class CommentEntity
{
    public string Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    public Guid PostId { get; set; }
    public PostEntity Post { get; set; }
    public string Caption { get; set; }
    public JsonElement Attachments { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
}