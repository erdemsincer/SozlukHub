using ReviewService.Dtos;

namespace ReviewService.Services
{
    public interface IReviewService
    {
        Task CreateReviewAsync(CreateReviewDto dto, int userId);
        Task<List<ReviewDto>> GetByEntryIdAsync(int entryId);
        Task<List<ReviewDto>> GetByUserIdAsync(int userId);
    }
}
