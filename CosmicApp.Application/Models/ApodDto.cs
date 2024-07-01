using CosmicApp.Domain.Entities;

namespace CosmicApp.Application.Models
{
    public class ApodDto
    {
        //public int Id { get; set; }

        public string? Date { get; set; }

        public string? Explanation { get; set; }

        public string? Url { get; set; }

        public string? Hdurl { get; set; }

        public string? Title { get; set; }

        public string? MediaType { get; set; }
    }
}
