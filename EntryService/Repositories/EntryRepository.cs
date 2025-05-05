using EntryService.Data;
using EntryService.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntryService.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private readonly EntryDbContext _context;

        public EntryRepository(EntryDbContext context)
        {
            _context = context;
        }

        public async Task<Entry?> GetByIdAsync(int id)
        {
            return await _context.Entries.FindAsync(id);
        }

        public async Task<List<Entry>> GetAllAsync()
        {
            return await _context.Entries.ToListAsync();
        }

        public async Task AddAsync(Entry entry)
        {
            await _context.Entries.AddAsync(entry);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
