using Forum.Application.Models;

namespace Forum.Application.Interfaces.Services;

public interface IPostsService
{
    Task<IEnumerable<Post>> GetAllPosts();
    Task<Post> GetPostById(Guid id);
    Task<Post> CreatePost(Post post);
    Task<Post> UpdatePost(Post post);
    Task<bool> DeletePost(Guid id);
}
