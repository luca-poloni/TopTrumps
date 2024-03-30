﻿namespace Domain.Game
{
    public interface IGameRepository
    {
        void Add(GameEntity game);
        void Update(GameEntity game);
        void Delete(GameEntity game);
        Task<GameEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<GameEntity>?> GetAllAsync(CancellationToken cancellationToken);
    }
}