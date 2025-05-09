using VoteService.Entities;

namespace VoteService.Repositories
{
    public interface IVoteRepository
    {
        Task<Vote?> GetVoteAsync(int entryId, int userId);
        Task<List<Vote>> GetVotesByEntryIdAsync(int entryId);
        Task AddVoteAsync(Vote vote);
        Task DeleteVoteAsync(Vote vote);
        Task SaveChangesAsync();

    }
}
