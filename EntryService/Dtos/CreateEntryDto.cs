namespace EntryService.Dtos
{
    public class CreateEntryDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int TopicId { get; set; }
    }
}
