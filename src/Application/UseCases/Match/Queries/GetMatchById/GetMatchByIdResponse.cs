﻿namespace Application.UseCases.Match.Queries
{
    public class GetMatchByIdResponse
    {
        public uint Id { get; init; }
        public uint GameId { get; init; }
        public bool IsFinish { get; init; }
    }
}
