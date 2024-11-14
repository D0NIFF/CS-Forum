using Forum.Application.Models;

namespace Forum.Application.Interfaces.Repositories;

public interface IPostsRepository
{
    Task<Post> GetById(Guid id);
    Task<IEnumerable<Post>> Get();
    Task<Post> Create(Post post);
    Task<Post> Update(Post post);
    Task<bool> Delete(Guid id);
}
