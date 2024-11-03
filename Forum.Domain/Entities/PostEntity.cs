namespace Forum.Domain.Entities;

public class PostEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    public Guid CategoryId { get; set; }
    public PostCategoryEntity Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
    public List<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
}
