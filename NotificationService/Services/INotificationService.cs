using NotificationService.Entities;

namespace NotificationService.Services
{
    public interface INotificationService
    {
        Task<List<Notification>> GetNotificationsAsync(int userId);
        Task CreateNotificationAsync(int userId, string message);
        Task MarkAsReadAsync(int id);
    }
}
