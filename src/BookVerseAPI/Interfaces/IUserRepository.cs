using BookVerseAPI.Models;

namespace BookVerseAPI.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid id);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(Guid id);
}
