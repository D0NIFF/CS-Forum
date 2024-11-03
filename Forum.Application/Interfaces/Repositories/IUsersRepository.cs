using Forum.Application.Models;

namespace Forum.Application.Interfaces.Repositories;

public interface IUsersRepository
{
    Task<User> GetUserById(Guid id);
    Task<User> GetUserByNickname(string nickname);
    Task<User> GetUserByEmail(string email);
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(User user);
    Task<User> UpdateUserById(Guid id, User user);
    Task<User> DeleteUser(Guid id);
}
