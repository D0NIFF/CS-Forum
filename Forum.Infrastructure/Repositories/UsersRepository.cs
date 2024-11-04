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

    /// <summary>
    /// Get one user by ID
    /// </summary>
    /// <param name="id">User ID</param>
    /// <returns></returns>
    public async Task<User> GetUserById(Guid id)
    {
        var user = await _context.Users
            .Where (u => u.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return User.CreateFromEntity(user);
    }

    public async Task<User> GetUserByNickname(string nickname)
    {
        var user = await _context.Users
            .Where(x => x.Nickname == nickname)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return User.CreateFromEntity(user);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _context.Users
            .Where(x => x.Email == email)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return User.CreateFromEntity(user);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users
            .AsNoTracking()
            .Select(u => User.CreateFromEntity(u))
            .ToListAsync();
    }

    public async Task<User> CreateUser(User user)
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

    public async Task<User> UpdateUser(User user)
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

    public async Task<bool> DeleteUser(Guid id)
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
