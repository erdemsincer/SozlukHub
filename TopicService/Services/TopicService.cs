using TopicService.Entities;
using TopicService.Repositories;

namespace TopicService.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Topic?> GetByIdAsync(int id)
        {
            return await _topicRepository.GetByIdAsync(id);
        }

        public async Task<List<Topic>> GetAllAsync()
        {
            return await _topicRepository.GetAllAsync();
        }

        public async Task CreateTopicAsync(Topic topic)
        {
            await _topicRepository.AddAsync(topic);
            await _topicRepository.SaveChangesAsync();
        }
    }
}
