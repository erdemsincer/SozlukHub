using EntryService.Dtos;
using EntryService.Entities;

namespace EntryService.Services
{
    public interface IEntryService
    {
        Task<List<EntryDto>> GetAllAsync();
        Task<EntryDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateEntryDto dto, int userId, string username);
        Task DeleteAsync(int id);
        Task<List<EntryDto>> GetEntriesByTopicIdAsync(int topicId);

    }
}
