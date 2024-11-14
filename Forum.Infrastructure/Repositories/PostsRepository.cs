using Forum.Application.Models;
using Forum.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Forum.Domain.Entities;

namespace Forum.Infrastructure.Repositories;

public class PostsRepository : IPostsRepository
{
    private readonly ForumDbContext _context;

    public PostsRepository(ForumDbContext context)
    {
        _context = context;
    }

    public async Task<Post> GetById(Guid id)
    {
        var post = await _context.Posts
            .Where (u => u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return Post.CreateFromEntity(post);
    }

    public async Task<IEnumerable<Post>> Get()
    {
        return await _context.Posts
            .AsNoTracking()
            .Select(p => Post.CreateFromEntity(p))
            .ToListAsync();
    }

    public async Task<Post> Create(Post post)
    {
        var postEntity = new PostEntity
        {
            Title = post.Title,
            Description = post.Description,
            UserId = post.UserId,
            CategoryId = post.CategoryId,
            CreatedAt = post.CreatedAt,
            UpdatedAt = post.UpdatedAt,
        };
        await _context.Posts.AddAsync(postEntity);
        await _context.SaveChangesAsync();

        return post;
    }

    public async Task<Post> Update(Post post)
    {
        var postEntity = new PostEntity
        {
            Title = post.Title,
            Description = post.Description,
            UserId = post.UserId,
            CategoryId = post.CategoryId,
            CreatedAt = post.CreatedAt,
            UpdatedAt = post.UpdatedAt,
        };
        _context.Posts
            .Update(postEntity);
        _context.SaveChangesAsync();
        return post;
    }

    public async Task<bool> Delete(Guid id)
    {
        var post = await _context.Posts
            .Where (x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
            
        if(post == null) return false;

        _context.Posts
            .Remove(post);
        return true;
    }
}
