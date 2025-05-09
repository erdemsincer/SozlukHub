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

        public async Task<List<Entry>> GetAllAsync()
        {
            return await _context.Entries
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<Entry?> GetByIdAsync(int id)
        {
            return await _context.Entries.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task CreateAsync(Entry entry)
        {
            await _context.Entries.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entry = await _context.Entries.FindAsync(id);
            if (entry != null)
            {
                entry.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Entry>> GetEntriesByTopicIdAsync(int topicId)
        {
            return await _context.Entries
                .Where(e => e.TopicId == topicId && !e.IsDeleted)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }


    }
}
