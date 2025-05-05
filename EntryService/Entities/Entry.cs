namespace EntryService.Entities
{
    public class Entry
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        public int TopicId { get; set; }           // 👈 Topic ilişkisi
        public int UserId { get; set; }            // 👈 Auth token’dan alınacak
        public string Username { get; set; } = ""; // 👈 Auth token’dan alınacak

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        // (İleride VoteService ile entegre olursa güncellenir)
        public int LikeCount { get; set; } = 0;
        public int DislikeCount { get; set; } = 0;
    }
}
