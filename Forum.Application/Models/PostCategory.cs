using Forum.Domain.Entities;

namespace Forum.Application.Models;

public class PostCategory
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public List<Post> Posts { get; init; } = new List<Post>();

    public static PostCategory CreateFromEntity(PostCategoryEntity entity)
    {
        return new PostCategory()
        {
            Id = entity.Id,
            Title = entity.Title
        };
    }

    public static PostCategory CreateFromDto(string title)
    {
        PostCategory postCategory = new PostCategory()
        {
            Id = Guid.NewGuid(),
            Title = title
        };

        return postCategory;
    }
}
