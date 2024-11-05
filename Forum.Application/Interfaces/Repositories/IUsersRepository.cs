using Forum.Application.Models;

namespace Forum.Application.Interfaces.Repositories;

public interface IUsersRepository
{
    Task<User> GetById(Guid id);
    Task<User> GetByNickname(string nickname);
    Task<User> GetByEmail(string email);
    Task<IEnumerable<User>> Get();
    Task<User> Create(User user);
    Task<User> Update(User user);
    Task<bool> Delete(Guid id);
}
