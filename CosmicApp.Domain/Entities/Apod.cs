using System.Text.Json.Serialization;

namespace CosmicApp.Domain.Entities
{
    public class Apod
    {
        public int Id { get; set; }

        public string? Date { get; set; }

        public string? Explanation { get; set; }

        public string? Url { get; set; }

        public string? Hdurl { get; set; }

        public string? Title { get; set; }

        [JsonPropertyName("media_type")]
        public string? MediaType { get; set; }

        //public User Owner { get; set; } = default!;
        //public string OwnerId { get; set; } = default!;
    }
}
