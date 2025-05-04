using UserService.Entities;
using UserService.Repositories;
using UserService.Dtos;

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

        public async Task UpdateProfileAsync(int id, string? avatarUrl, string? bio)
        {
            await _repo.UpdateProfileAsync(id, avatarUrl, bio);
            await _repo.SaveChangesAsync();
        }

    }
}
