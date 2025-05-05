using EntryService.Entities;

namespace EntryService.Repositories
{
    public interface IEntryRepository
    {
        Task<Entry?> GetByIdAsync(int id);
        Task<List<Entry>> GetAllAsync();
        Task AddAsync(Entry entry);
        Task SaveChangesAsync();
    }
}
