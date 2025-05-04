using UserService.Entities;

namespace UserService.Services
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(int id);
        Task CreateUserAsync(User user);
    }
}
