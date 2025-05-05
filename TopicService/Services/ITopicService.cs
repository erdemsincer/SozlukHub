using TopicService.Entities;

namespace TopicService.Services
{
    public interface ITopicService
    {
        Task<Topic?> GetByIdAsync(int id);
        Task<List<Topic>> GetAllAsync();
        Task CreateTopicAsync(Topic topic);
    }
}
