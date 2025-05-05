using EntryService.Entities;
using EntryService.Repositories;

namespace EntryService.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;

        public EntryService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<Entry?> GetByIdAsync(int id)
        {
            return await _entryRepository.GetByIdAsync(id);
        }

        public async Task<List<Entry>> GetAllAsync()
        {
            return await _entryRepository.GetAllAsync();
        }

        public async Task CreateEntryAsync(Entry entry)
        {
            await _entryRepository.AddAsync(entry);
            await _entryRepository.SaveChangesAsync();
        }
    }
}
