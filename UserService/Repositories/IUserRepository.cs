using UserService.Entities;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task SaveChangesAsync();
        Task UpdateProfileAsync(int id, string avatarUrl, string bio);
    }
}
