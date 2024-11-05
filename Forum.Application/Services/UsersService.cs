using Forum.Application.Interfaces.Repositories;
using Forum.Application.Interfaces.Services;
using Forum.Application.Models;

namespace Forum.Application.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _usersRepository.Get();
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _usersRepository.GetById(id);
    }

    public async Task<User> GetUserByNickname(string nickname)
    {
        return await _usersRepository.GetByNickname(nickname);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _usersRepository.GetByEmail(email);
    }

    public async Task<User> CreateUser(User user)
    {
        return await _usersRepository.Create(user);
    }

    public async Task<User> UpdateUser(User user)
    {
        return await _usersRepository.Update(user);
    }
    public async Task<bool> DeleteUser(Guid id)
    {
        return await _usersRepository.Delete(id);
    }
}
