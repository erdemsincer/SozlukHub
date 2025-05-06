using MassTransit;
using NotificationService.Services;
using Shared.Contracts;

namespace NotificationService.Consumers
{
    public class EntryCreatedConsumer : IConsumer<EntryCreatedEvent>
    {
        private readonly INotificationService _notificationService;

        public EntryCreatedConsumer(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Consume(ConsumeContext<EntryCreatedEvent> context)
        {
            var message = context.Message;
            var userId = message.UserId;

            var notificationMessage = $"Yeni bir entry oluşturuldu. EntryId: {message.EntryId}";

            await _notificationService.CreateNotificationAsync(userId, notificationMessage);

            Console.WriteLine($"[Notification] EntryCreatedEvent işlendi: EntryId={message.EntryId}, UserId={userId}");
        }
    }
}
