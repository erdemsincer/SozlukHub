using Microsoft.EntityFrameworkCore;
using TopicService.Data;
using TopicService.Entities;

namespace TopicService.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly TopicDbContext _context;

        public TopicRepository(TopicDbContext context)
        {
            _context = context;
        }

        public async Task<Topic?> GetByIdAsync(int id)
        {
            return await _context.Topics.FindAsync(id);
        }

        public async Task<List<Topic>> GetAllAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task AddAsync(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
