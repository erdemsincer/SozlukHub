using MassTransit;
using Shared.Contracts; // VoteAddedEvent için
using VoteService.Dtos;
using VoteService.Entities;
using VoteService.Repositories;

namespace VoteService.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _repo;
        private readonly IPublishEndpoint _publish;

        public VoteService(IVoteRepository repo, IPublishEndpoint publish)
        {
            _repo = repo;
            _publish = publish;
        }

        public async Task<bool> AddVoteAsync(CreateVoteDto dto, int userId)
        {
            var existing = await _repo.GetVoteAsync(dto.EntryId, userId);
            if (existing != null)
                return false;

            var vote = new Vote
            {
                EntryId = dto.EntryId,
                UserId = userId,
                IsUpvote = dto.IsUpvote
            };

            await _repo.AddVoteAsync(vote);
            await _repo.SaveChangesAsync();

            // 🔥 VoteAddedEvent publish et
            await _publish.Publish(new VoteAddedEvent
            {
                EntryId = vote.EntryId,
                UserId = vote.UserId,
                IsUpvote = vote.IsUpvote

            });

            return true;
        }

        public async Task<bool> RemoveVoteAsync(int entryId, int userId)
        {
            var existing = await _repo.GetVoteAsync(entryId, userId);
            if (existing == null)
                return false;

            await _repo.DeleteVoteAsync(existing);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<VoteCountDto> GetVoteCountAsync(int entryId)
        {
            var votes = await _repo.GetVotesByEntryIdAsync(entryId);

            return new VoteCountDto
            {
                Upvotes = votes.Count(v => v.IsUpvote),
                Downvotes = votes.Count(v => !v.IsUpvote)
            };
        }
    }
}
