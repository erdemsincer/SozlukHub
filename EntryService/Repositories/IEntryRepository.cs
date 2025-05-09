using EntryService.Entities;

namespace EntryService.Repositories
{
    public interface IEntryRepository
    {
        Task<List<Entry>> GetAllAsync();
        Task<Entry?> GetByIdAsync(int id);
        Task CreateAsync(Entry entry);
        Task DeleteAsync(int id); // Soft delete
        Task<List<Entry>> GetEntriesByTopicIdAsync(int topicId);

    }
}
