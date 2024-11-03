namespace Forum.Domain.Entities;

public class PostCategoryEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<PostEntity> Posts { get; init; } = new List<PostEntity>();
}
