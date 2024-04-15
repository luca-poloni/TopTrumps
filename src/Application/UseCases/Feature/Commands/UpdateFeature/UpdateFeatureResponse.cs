﻿namespace Application.UseCases.Feature.Commands.UpdateFeature
{
    public record UpdateFeatureResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public string Name { get; set; } = null!;
    }
}
