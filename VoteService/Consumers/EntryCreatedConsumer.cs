using MassTransit;
using Shared.Contracts;
using VoteService.Dtos;
using VoteService.Services;

namespace VoteService.Consumers
{
    public class EntryCreatedConsumer : IConsumer<EntryCreatedEvent>
    {
        private readonly IVoteService _voteService;

        public EntryCreatedConsumer(IVoteService voteService)
        {
            _voteService = voteService;
        }

        public async Task Consume(ConsumeContext<EntryCreatedEvent> context)
        {
            var message = context.Message;

            Console.WriteLine($"[VoteService] EntryCreatedEvent received: EntryId={message.EntryId}, UserId={message.UserId}");

            // Entry oluşturulunca, varsayılan olarak oylama başlatabilirsiniz
            // Örneğin: Yeni entry için kullanıcıya 1 oy verilmesi
            var createVoteDto = new CreateVoteDto
            {
                EntryId = message.EntryId,
                IsUpvote = true // Burada oyu yukarı yönlü (upvote) başlatabilirsiniz, ihtiyaçlarınıza göre değiştirebilirsiniz
            };

            var success = await _voteService.AddVoteAsync(createVoteDto, message.UserId);
            if (success)
            {
                Console.WriteLine($"Vote successfully added for EntryId: {message.EntryId}");
            }
            else
            {
                Console.WriteLine($"Failed to add vote for EntryId: {message.EntryId}");
            }
        }
    }
}
