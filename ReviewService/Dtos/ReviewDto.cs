namespace ReviewService.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int EntryId { get; set; }
        public string EntryTitle { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
