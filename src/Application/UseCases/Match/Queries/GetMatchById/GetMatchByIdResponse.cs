﻿namespace Application.UseCases.Match.Queries.GetMatchById
{
    public record GetMatchByIdResponse
    {
        public Guid Id { get; set; } = default;
        public Guid GameId { get; set; } = default;
        public Guid? WinnerPlayerId { get; set; } 
    }
}
