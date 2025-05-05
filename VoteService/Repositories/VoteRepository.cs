using Microsoft.EntityFrameworkCore;
using VoteService.Data;
using VoteService.Entities;

namespace VoteService.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly VoteDbContext _context;

        public VoteRepository(VoteDbContext context)
        {
            _context = context;
        }

        public async Task<Vote?> GetVoteAsync(int entryId, int userId)
        {
            return await _context.Votes
                .FirstOrDefaultAsync(v => v.EntryId == entryId && v.UserId == userId);
        }

        public async Task<List<Vote>> GetVotesByEntryIdAsync(int entryId)
        {
            return await _context.Votes
                .Where(v => v.EntryId == entryId)
                .ToListAsync();
        }

        public async Task AddVoteAsync(Vote vote)
        {
            await _context.Votes.AddAsync(vote);
        }

        public async Task DeleteVoteAsync(Vote vote)
        {
            _context.Votes.Remove(vote);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
