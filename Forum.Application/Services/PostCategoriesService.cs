using Forum.Application.Interfaces.Repositories;
using Forum.Application.Interfaces.Services;
using Forum.Application.Models;

namespace Forum.Application.Services;

public class PostCategoriesService : IPostCategoriesService
{
    private readonly IPostCategoriesRepository _postCategoriesRepository;

    public PostCategoriesService(IPostCategoriesRepository postCategoriesRepository)
    {
        _postCategoriesRepository = postCategoriesRepository;
    }

    async Task<PostCategory> IPostCategoriesService.CreatePostCategory(PostCategory postCategory)
    {
        return await _postCategoriesRepository.Create(postCategory);
    }

    async Task<bool> IPostCategoriesService.DeletePostCategory(Guid id)
    {
        return await _postCategoriesRepository.Delete(id);
    }

    async Task<IEnumerable<PostCategory>> IPostCategoriesService.GetAllPostCategories()
    {
        return await _postCategoriesRepository.Get();
    }

    async Task<PostCategory> IPostCategoriesService.GetPostCategoryById(Guid id)
    {
        return await _postCategoriesRepository.GetById(id);
    }

    async Task<PostCategory> IPostCategoriesService.UpdatePostCategory(PostCategory postCategory)
    {
        return await _postCategoriesRepository.Update(postCategory);
    }
}
