using ReviewService.Dtos;
using ReviewService.Entities;
using ReviewService.Repositories;

namespace ReviewService.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repo;
        private readonly HttpClient _http;

        public ReviewService(IReviewRepository repo, IHttpClientFactory httpClientFactory)
        {
            _repo = repo;
            _http = httpClientFactory.CreateClient();
        }

        public async Task CreateReviewAsync(CreateReviewDto dto, int userId)
        {
            var review = new Review
            {
                EntryId = dto.EntryId,
                UserId = userId,
                Content = dto.Content
            };

            await _repo.AddAsync(review);
            await _repo.SaveChangesAsync();
        }

        public async Task<List<ReviewDto>> GetByEntryIdAsync(int entryId)
        {
            var reviews = await _repo.GetByEntryIdAsync(entryId);
            var result = new List<ReviewDto>();

            foreach (var review in reviews)
            {
                var entryTitle = await GetEntryTitleAsync(review.EntryId);
                var username = await GetUsernameAsync(review.UserId);

                result.Add(new ReviewDto
                {
                    Id = review.Id,
                    EntryId = review.EntryId,
                    EntryTitle = entryTitle,
                    UserId = review.UserId,
                    Username = username,
                    Content = review.Content,
                    CreatedAt = review.CreatedAt
                });
            }

            return result;
        }

        public async Task<List<ReviewDto>> GetByUserIdAsync(int userId)
        {
            var reviews = await _repo.GetByUserIdAsync(userId);
            var result = new List<ReviewDto>();

            foreach (var review in reviews)
            {
                var entryTitle = await GetEntryTitleAsync(review.EntryId);
                var username = await GetUsernameAsync(review.UserId);

                result.Add(new ReviewDto
                {
                    Id = review.Id,
                    EntryId = review.EntryId,
                    EntryTitle = entryTitle,
                    UserId = review.UserId,
                    Username = username,
                    Content = review.Content,
                    CreatedAt = review.CreatedAt
                });
            }

            return result;
        }

        private async Task<string> GetEntryTitleAsync(int entryId)
        {
            try
            {
                var response = await _http.GetAsync($"http://entryservice-api:8080/api/Entry/{entryId}");
                if (!response.IsSuccessStatusCode) return "Bilinmiyor";

                var entry = await response.Content.ReadFromJsonAsync<EntryResponse>();
                return entry?.Title ?? "Bilinmiyor";
            }
            catch
            {
                return "Bilinmiyor";
            }
        }

        private async Task<string> GetUsernameAsync(int userId)
        {
            try
            {
                var response = await _http.GetAsync($"http://userservice-api:8080/api/User/{userId}");
                if (!response.IsSuccessStatusCode) return "Bilinmiyor";

                var user = await response.Content.ReadFromJsonAsync<UserResponse>();
                return user?.Username ?? "Bilinmiyor";
            }
            catch
            {
                return "Bilinmiyor";
            }
        }

        private class EntryResponse
        {
            public string Title { get; set; } = string.Empty;
        }

        private class UserResponse
        {
            public string Username { get; set; } = string.Empty;
        }
    }
}
