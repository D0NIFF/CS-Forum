using Forum.Application.Models;
using Forum.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Forum.Domain.Entities;

namespace Forum.Infrastructure.Repositories;

public class PostCategoriesRepository : IPostCategoriesRepository
{
    private readonly ForumDbContext _context;

    public PostCategoriesRepository(ForumDbContext context)
    {
        _context = context;
    }

    public async Task<PostCategory> GetById(Guid id)
    {
        var postCategory = await _context.PostCategories
            .Where (u => u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return PostCategory.CreateFromEntity(postCategory);
    }

    public async Task<IEnumerable<PostCategory>> Get()
    {
        return await _context.PostCategories
            .AsNoTracking()
            .Select(c => PostCategory.CreateFromEntity(c))
            .ToListAsync();
    }

    public async Task<PostCategory> Create(PostCategory postCategory)
    {
        var postCategoryEntity = new PostCategoryEntity
        {
            Id = postCategory.Id,
            Title = postCategory.Title,
        };
        await _context.PostCategories.AddAsync(postCategoryEntity);
        await _context.SaveChangesAsync();

        return postCategory;
    }

    public async Task<PostCategory> Update(PostCategory postCategory)
    {
        var postCategoryEntity = new PostCategoryEntity
        {
            Id = postCategory.Id,
            Title = postCategory.Title
        };
        _context.PostCategories
            .Update(postCategoryEntity);
        _context.SaveChangesAsync();
        return postCategory;
    }

    public async Task<bool> Delete(Guid id)
    {
        var userCategory = await _context.PostCategories
            .Where (x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
            
        if(userCategory == null) return false;

        _context.PostCategories
            .Remove(userCategory);
        return true;
    }
}
