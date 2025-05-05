using System.Text.Json.Serialization;

namespace EntryService.Dtos
{
    public class TopicResponse
    {
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Name { get; set; } = null!;
    }
}
