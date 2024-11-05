using Forum.Application.Models;
using Forum.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Forum.Domain.Entities;

namespace Forum.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ForumDbContext _context;

    public UsersRepository(ForumDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetById(Guid id)
    {
        var user = await _context.Users
            .Where (u => u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return User.CreateFromEntity(user);
    }

    public async Task<User> GetByNickname(string nickname)
    {
        var user = await _context.Users
            .Where(x => x.Nickname == nickname)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return User.CreateFromEntity(user);
    }

    public async Task<User> GetByEmail(string email)
    {
        var user = await _context.Users
            .Where(x => x.Email == email)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return User.CreateFromEntity(user);
    }

    public async Task<IEnumerable<User>> Get()
    {
        return await _context.Users
            .AsNoTracking()
            .Select(u => User.CreateFromEntity(u))
            .ToListAsync();
    }

    public async Task<User> Create(User user)
    {
        var userEntity = new UserEntity
        {
            Id = user.Id,
            Nickname = user.Nickname,
            Email = user.Email,
            Password = user.Password,
            RegisterIp = user.RegisterIp,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> Update(User user)
    {
        var userEntity = new UserEntity
        {
            Id = user.Id,
            Nickname = user.Nickname,
            Email = user.Email,
            Password = user.Password,
            RegisterIp = user.RegisterIp,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
        _context.Users
            .Update(userEntity);
        _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> Delete(Guid id)
    {
        var user = await _context.Users
            .Where (x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
            
        if(user == null) return false;

        _context.Users
            .Remove(user);
        return true;
    }
}
