namespace VoteService.Entities
{
    public class Vote
    {
        public int Id { get; set; }

        public int EntryId { get; set; }  // Hangi entry'e oy veriliyor
        public int UserId { get; set; }   // Oyu veren kullanıcı
        public bool IsUpvote { get; set; } // true: upvote, false: downvote

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
