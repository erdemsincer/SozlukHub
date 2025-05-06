using ReviewService.Entities;

namespace ReviewService.Repositories
{
    public interface IReviewRepository
    {
        Task AddAsync(Review review);
        Task<List<Review>> GetByEntryIdAsync(int entryId);
        Task<List<Review>> GetByUserIdAsync(int userId);
        Task SaveChangesAsync();
    }
}
