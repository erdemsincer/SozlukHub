using MassTransit;
using NotificationService.Services;
using Shared.Contracts;

namespace NotificationService.Consumers
{
    public class VoteAddedConsumer : IConsumer<VoteAddedEvent>
    {
        private readonly INotificationService _notificationService;

        public VoteAddedConsumer(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Consume(ConsumeContext<VoteAddedEvent> context)
        {
            var message = context.Message;

            string voteType = message.IsUpvote ? "beğeni" : "dislike";
            string content = $"EntryId: {message.EntryId} için bir {voteType} alındı.";

            await _notificationService.CreateNotificationAsync(message.UserId, content);

            Console.WriteLine($"[Notification] VoteAddedEvent işlendi: EntryId={message.EntryId}, UserId={message.UserId}");
        }
    }
}
