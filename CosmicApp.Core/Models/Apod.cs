using System.Text.Json.Serialization;

namespace CosmicApp.Core.Models
{
    public class Apod
    {
        public string? Date { get; set; }
        public string? Explanation { get; set; }
        public string? Url { get; set; }
        public string? Hdurl { get; set; }
        public string? Title { get; set; }
        [JsonPropertyName("media_type")]
        public string? MediaType { get; set; }
    }
}
