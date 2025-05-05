using MassTransit;
using Shared.Contracts;

namespace EntryService.Consumers
{
    public class EntryCreatedConsumer : IConsumer<EntryCreatedEvent>
    {
        private readonly ILogger<EntryCreatedConsumer> _logger;

        public EntryCreatedConsumer(ILogger<EntryCreatedConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<EntryCreatedEvent> context)
        {
            var message = context.Message;
            _logger.LogInformation("EntryCreatedEvent received: EntryId={EntryId}, UserId={UserId}", message.EntryId, message.UserId);

            // ❗ İstersen burada entry için başlangıçta 0 oylama kaydı başlatabilirsin
            // await _voteService.InitializeVotes(message.EntryId);

            await Task.CompletedTask;
        }
    }
}
