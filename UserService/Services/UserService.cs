using UserService.Entities;
using UserService.Repositories;

namespace UserService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<User?> GetByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task CreateUserAsync(User user)
        {
            await _repo.AddAsync(user);
            await _repo.SaveChangesAsync();
        }
    }
}
