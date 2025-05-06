namespace ReviewService.Dtos
{
    public class CreateReviewDto
    {
        public int EntryId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
