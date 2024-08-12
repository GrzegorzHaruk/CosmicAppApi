﻿using MediatR;

namespace CosmicApp.Application.Commands.CreateApods
{
    public class CreateApodCommand : IRequest<int>
    {
        public string? Date { get; set; }

        public string? Explanation { get; set; }

        public string Url { get; set; } = default!;

        public string? Hdurl { get; set; }

        public string? Title { get; set; }

        public string? MediaType { get; set; }
    }
}
