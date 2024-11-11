using Forum.Application.Models;

namespace Forum.Application.Interfaces.Services;

public interface IPostCategoriesService
{
    Task<IEnumerable<PostCategory>> GetAllPostCategories();
    Task<PostCategory> GetPostCategoryById(Guid id);
    Task<PostCategory> CreatePostCategory(PostCategory postCategory);
    Task<PostCategory> UpdatePostCategory(PostCategory postCategory);
    Task<bool> DeletePostCategory(Guid id);
}
