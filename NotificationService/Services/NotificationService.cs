using NotificationService.Entities;
using NotificationService.Repositories;

namespace NotificationService.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Notification>> GetNotificationsAsync(int userId)
        {
            return await _repository.GetAllAsync(userId);
        }

        public async Task CreateNotificationAsync(int userId, string message)
        {
            var notification = new Notification
            {
                UserId = userId,
                Message = message
            };

            await _repository.AddAsync(notification);
            await _repository.SaveChangesAsync();
        }

        public async Task MarkAsReadAsync(int id)
        {
            await _repository.MarkAsReadAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
