using EntryService.Dtos;
using EntryService.Entities;
using EntryService.Repositories;
using System.Text.Json;

namespace EntryService.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _repo;
        private readonly HttpClient _http;
        public EntryService(IEntryRepository repo, HttpClient http)
        {
            _repo = repo;
            _http = http;
        }

        public async Task<List<EntryDto>> GetAllAsync()
        {
            var entries = await _repo.GetAllAsync();
            var result = new List<EntryDto>();

            foreach (var e in entries)
            {
                string topicName = "";

                try
                {
                    var response = await _http.GetAsync($"http://topicservice-api:8080/api/Topic/{e.TopicId}");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var topic = JsonSerializer.Deserialize<TopicResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        topicName = topic?.Name ?? "";
                    }
                }
                catch
                {
                    topicName = "";
                }

                result.Add(new EntryDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Content = e.Content,
                    TopicId = e.TopicId,
                    TopicName = topicName,
                    UserId = e.UserId,
                    Username = e.Username,
                    CreatedAt = e.CreatedAt,
                    LikeCount = e.LikeCount,
                    DislikeCount = e.DislikeCount
                });
            }

            return result;
        }


        public async Task<EntryDto?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            if (e == null) return null;

            string topicName = "";
            try
            {
                var response = await _http.GetAsync($"http://topicservice-api:8080/api/Topic/{e.TopicId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var topic = JsonSerializer.Deserialize<TopicResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    topicName = topic?.Name ?? "";
                }
            }
            catch
            {
                topicName = "";
            }

            return new EntryDto
            {
                Id = e.Id,
                Title = e.Title,
                Content = e.Content,
                TopicId = e.TopicId,
                TopicName = topicName,
                UserId = e.UserId,
                Username = e.Username,
                CreatedAt = e.CreatedAt,
                LikeCount = e.LikeCount,
                DislikeCount = e.DislikeCount
            };
        }


        public async Task CreateAsync(CreateEntryDto dto, int userId, string username)
        {
            var entry = new Entry
            {
                Title = dto.Title,
                Content = dto.Content,
                TopicId = dto.TopicId,
                UserId = userId,
                Username = username
            };
            await _repo.CreateAsync(entry);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
