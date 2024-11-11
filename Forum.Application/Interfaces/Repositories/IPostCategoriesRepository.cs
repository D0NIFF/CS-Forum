using Forum.Application.Models;

namespace Forum.Application.Interfaces.Repositories;

public interface IPostCategoriesRepository
{
    Task<PostCategory> GetById(Guid id);
    Task<IEnumerable<PostCategory>> Get();
    Task<PostCategory> Create(PostCategory postCategory);
    Task<PostCategory> Update(PostCategory postCategory);
    Task<bool> Delete(Guid id);
}
