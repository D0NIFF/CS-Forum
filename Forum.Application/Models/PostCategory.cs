namespace Forum.Application.Models;

public class PostCategory
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public List<Post> Posts { get; init; } = new List<Post>();
}
