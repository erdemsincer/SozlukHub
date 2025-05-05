namespace VoteService.Dtos
{
    public class CreateVoteDto
    {
        public int EntryId { get; set; }
        public bool IsUpvote { get; set; }
    }
}
