using Forum.Domain.Entities;

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


    public static Post CreateFromEntity(PostEntity entity)
    {
        return new Post()
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            UserId = entity.UserId,
            CategoryId = entity.CategoryId,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
        };
    }

    public static Post CreateFromDto(string title, string description, Guid userId, Guid categoryId)
    {
        Post post = new Post()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            UserId = userId,
            CategoryId = categoryId,
            CreatedAt = DateTime.Now,
        };

        return post;
    }
}
