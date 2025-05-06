using NotificationService.Entities;

namespace NotificationService.Repositories
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetAllAsync(int userId);
        Task<Notification?> GetByIdAsync(int id);
        Task AddAsync(Notification notification);
        Task MarkAsReadAsync(int id);
        Task SaveChangesAsync();
    }
}
