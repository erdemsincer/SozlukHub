using EntryService.Dtos;
using EntryService.Entities;
using EntryService.Repositories;

namespace EntryService.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _repo;

        public EntryService(IEntryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<EntryDto>> GetAllAsync()
        {
            var entries = await _repo.GetAllAsync();
            return entries.Select(e => new EntryDto
            {
                Id = e.Id,
                Title = e.Title,
                Content = e.Content,
                TopicId = e.TopicId,
                UserId = e.UserId,
                Username = e.Username,
                CreatedAt = e.CreatedAt,
                LikeCount = e.LikeCount,
                DislikeCount = e.DislikeCount
            }).ToList();
        }

        public async Task<EntryDto?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            return e == null ? null : new EntryDto
            {
                Id = e.Id,
                Title = e.Title,
                Content = e.Content,
                TopicId = e.TopicId,
                UserId = e.UserId,
                Username = e.Username,
                CreatedAt = e.CreatedAt,
                LikeCount = e.LikeCount,
                DislikeCount = e.DislikeCount
            };
        }

        public async Task CreateAsync(CreateEntryDto dto, int userId, string username)
        {
            var entry = new Entry
            {
                Title = dto.Title,
                Content = dto.Content,
                TopicId = dto.TopicId,
                UserId = userId,
                Username = username
            };
            await _repo.CreateAsync(entry);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
