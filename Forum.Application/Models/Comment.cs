using System.Text.Json;

namespace Forum.Application.Models;

public class Comment
{
    public string Id { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }

    public Guid PostId { get; set; }

    public Post Post { get; set; }

    public string Caption { get; set; }

    public JsonElement Attachments { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; }
}