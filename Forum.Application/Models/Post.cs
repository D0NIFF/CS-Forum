namespace Forum.Application.Models;

public class Post
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }
    public Guid UserId { get; set; }

    public User User { get; set; }

    public Guid CategoryId { get; set; }

    public PostCategory Category { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; }

    public List<Comment> Comments { get; set; } = new List<Comment>();

}
