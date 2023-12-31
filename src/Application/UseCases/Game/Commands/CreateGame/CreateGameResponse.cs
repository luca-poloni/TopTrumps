﻿namespace Application.UseCases.Game.Commands
{
    public record CreateGameResponse
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
