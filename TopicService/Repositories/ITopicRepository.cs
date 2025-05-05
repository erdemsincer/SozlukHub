using TopicService.Entities;

namespace TopicService.Repositories
{
    public interface ITopicRepository
    {
        Task<Topic?> GetByIdAsync(int id);
        Task<List<Topic>> GetAllAsync();
        Task AddAsync(Topic topic);
        Task SaveChangesAsync();
    }
}
