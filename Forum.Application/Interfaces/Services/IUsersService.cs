using Forum.Application.Models;

namespace Forum.Application.Interfaces.Services;

public interface IUsersService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(Guid id);
    Task<User> GetUserByNickname(string nickname);
    Task<User> GetUserByEmail(string email);
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(User user);
    Task<bool> DeleteUser(Guid id);
}
