namespace ReviewService.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public int EntryId { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
