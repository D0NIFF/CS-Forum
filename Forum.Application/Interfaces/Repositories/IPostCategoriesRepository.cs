using Forum.Application.Models;

namespace Forum.Application.Interfaces.Repositories;

public interface IPostCategoriesRepository
{
    Task<User> GetById(Guid id);
    Task<IEnumerable<User>> Get();
    Task<User> Create(User user);
    Task<User> Update(User user);
    Task<bool> Delete(Guid id);
}
