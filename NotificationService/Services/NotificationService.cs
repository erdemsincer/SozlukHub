using NotificationService.Entities;
using NotificationService.Models;
using NotificationService.Repositories;
using NotificationService.Services.Mail;
using System.Net.Http.Json;

namespace NotificationService.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;
        private readonly IMailService _mail;
        private readonly HttpClient _http;

        public NotificationService(
            INotificationRepository repository,
            IMailService mail,
            IHttpClientFactory httpClientFactory)
        {
            _repository = repository;
            _mail = mail;
            _http = httpClientFactory.CreateClient();
        }

        public async Task<List<Notification>> GetNotificationsAsync(int userId)
        {
            return await _repository.GetAllAsync(userId);
        }

        public async Task CreateNotificationAsync(int userId, string message)
        {
            // 1. Veritabanına bildirim kaydı
            var notification = new Notification
            {
                UserId = userId,
                Message = message,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(notification);
            await _repository.SaveChangesAsync();

            // 2. UserService'ten kullanıcı bilgisi çek
            var response = await _http.GetAsync($"http://userservice-api:8080/api/User/{userId}");
            if (!response.IsSuccessStatusCode) return;

            var user = await response.Content.ReadFromJsonAsync<UserResponseDto>();
            if (user == null || string.IsNullOrEmpty(user.Email)) return;

            // 3. E-posta gönder
            await _mail.SendEmailAsync(
     user.Email,
     "SözlükHub Bildirimi",
     $"""
    <html>
      <body style="font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 30px;">
        <div style="max-width: 600px; margin: auto; background-color: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1);">
          <h2 style="color: #2c3e50;">Merhaba {user.Username},</h2>
          <p style="font-size: 16px; color: #333;">{message}</p>
          <hr style="border: none; border-top: 1px solid #ddd; margin: 20px 0;">
          <p style="font-size: 12px; color: #999;">Bu e-posta, SözlükHub platformu üzerinden otomatik olarak gönderilmiştir.</p>
        </div>
      </body>
    </html>
    """
 );
        }

        public async Task MarkAsReadAsync(int id)
        {
            await _repository.MarkAsReadAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
