using VoteService.Dtos;

namespace VoteService.Services
{
    public interface IVoteService
    {
        Task<bool> AddVoteAsync(CreateVoteDto dto, int userId);
        Task<bool> RemoveVoteAsync(int entryId, int userId);
        Task<VoteCountDto> GetVoteCountAsync(int entryId);
        Task<UserVoteStatusDto> GetUserVoteStatusAsync(int entryId, int userId);

    }
}
