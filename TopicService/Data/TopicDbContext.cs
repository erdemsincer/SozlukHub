using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TopicService.Entities;

namespace TopicService.Data
{
    public class TopicDbContext : DbContext
    {
        public TopicDbContext(DbContextOptions<TopicDbContext> options) : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }
    }
}
