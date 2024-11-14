using Forum.Application.Interfaces.Repositories;
using Forum.Application.Interfaces.Services;
using Forum.Application.Models;

namespace Forum.Application.Services;

public class PostsService : IPostsService
{
    private readonly IPostsRepository _postsRepository;

    public PostsService(IPostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }

    async Task<Post> IPostsService.CreatePost(Post post)
    {
        return await _postsRepository.Create(post);
    }

    async Task<bool> IPostsService.DeletePost(Guid id)
    {
        return await _postsRepository.Delete(id);
    }

    async Task<IEnumerable<Post>> IPostsService.GetAllPosts()
    {
        return await _postsRepository.Get();
    }

    async Task<Post> IPostsService.GetPostById(Guid id)
    {
        return await _postsRepository.GetById(id);
    }

    async Task<Post> IPostsService.UpdatePost(Post post)
    {
        return await _postsRepository.Update(post);
    }
}
