using EntryService.Entities;

namespace EntryService.Services
{
    public interface IEntryService
    {
        Task<Entry?> GetByIdAsync(int id);
        Task<List<Entry>> GetAllAsync();
        Task CreateEntryAsync(Entry entry)
    }
}
