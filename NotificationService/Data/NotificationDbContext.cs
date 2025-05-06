using Microsoft.EntityFrameworkCore;
using NotificationService.Entities;
using System.Collections.Generic;

namespace NotificationService.Data
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options) { }

        public DbSet<Notification> Notifications => Set<Notification>();
    }
}
