﻿using Domain.Common.Primitives;
using Domain.Game.Exceptions;

namespace Domain.Game.Entities
{
    public class MatchEntity : BaseAuditableEntity
    {
        public Guid GameId { get; set; } = default;
        public Guid? WinnerPlayerId { get; set; }
        public GameAggregate Game { get; set; } = null!;
        public PlayerEntity? WinnerPlayer { get; set; }
        public List<PlayerEntity> Players { get; set; } = [];
        public List<RoundEntity> Rounds { get; set; } = [];
        public List<MatchCardEntity> MatchCards { get; set; } = [];

        public void Update(Guid winnerPlayerId)
        {
            WinnerPlayerId = winnerPlayerId;
        }

        public void AddMatchCards()
        {
            Game.ShuffledCards().ForEach(card => MatchCards.Add(new MatchCardEntity(this, card)));
        }

        public int MatchCardsPerPlayer()
        {
            return MatchCards.Count / Players.Count;
        }

        public void GiveMatchCardsToPlayers(int matchCardsPerPlayer)
        {
            foreach (var player in Players.Where(player => player.IsNotAvailable()))
                player.TakeMatchCards(MatchCardsToPlayer(matchCardsPerPlayer));
        }

        private List<MatchCardEntity> MatchCardsToPlayer(int matchCardsPerPlayer)
        {
            var matchCardsToGive = MatchCards.Where(matchCard => matchCard.IsNotUsed())?.Take(matchCardsPerPlayer)?.ToList();

            if (matchCardsToGive == default || matchCardsToGive.Count == default)
                throw new HasNoMoreCardsToGiveException();

            matchCardsToGive.ForEach(matchCardToGive => matchCardToGive.UseCard());

            return matchCardsToGive;
        }

        public List<PlayerEntity.PlayerCardEntity> PickUpPlayerCardFromPlayers()
        {
            return Players.Select(player => player.PickUpPlayerCard()).ToList();
        }

        public PlayerEntity? Winner()
        {
            var availablePlayers = AvailablePlayers();

            var isNotFinish = availablePlayers == default || availablePlayers.Count > 1;

            if (isNotFinish)
                return default;

            WinnerPlayer = availablePlayers?.SingleOrDefault();

            return WinnerPlayer;
        }

        private List<PlayerEntity> AvailablePlayers()
        {
            return Players.Where(player => player.IsAvailable()).ToList();
        }

        public PlayerEntity AddPlayer(string name)
        {
            var player = new PlayerEntity
            {
                MatchId = Id,
                Name = name
            };

            Players.Add(player);

            return player;
        }

        public PlayerEntity SinglePlayer()
        {
            return Players
                .SingleOrDefault() ?? throw new SinglePlayerNotFoundException();
        }

        public void RemoveSinglePlayer()
        {
            Players.Remove(SinglePlayer());
        }

        public RoundEntity AddRound()
        {
            var round = new RoundEntity
            {
                MatchId = Id
            };

            Rounds.Add(round);

            return round;
        }

        public RoundEntity SingleRound()
        {
            return Rounds
                .SingleOrDefault() ?? throw new SingleRoundNotFoundException();
        }

        public void RemoveSingleRound()
        {
            Rounds.Remove(SingleRound());
        }

        public class MatchCardEntity() : BaseAuditableDateEntity
        {
            public Guid MatchId { get; set; } = default;
            public Guid CardId { get; set; } = default;
            public bool Used { get; set; } = default;
            public MatchEntity Match { get; set; } = null!;
            public CardEntity Card { get; set; } = null!;
            public List<PlayerEntity.PlayerCardEntity> PlayerCards { get; set; } = [];

            public MatchCardEntity(MatchEntity match, CardEntity card) : this()
            {
                Match = match;
                Card = card;
            }

            public bool IsNotUsed()
            {
                return !Used;
            }

            public void UseCard()
            {
                Used = true;
            }
        }
    }
}
