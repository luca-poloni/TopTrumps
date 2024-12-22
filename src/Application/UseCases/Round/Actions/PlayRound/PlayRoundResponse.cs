namespace Application.UseCases.Round.Actions.PlayRound
{
    public record PlayRoundResponse
    {
        public Guid WinnerPlayerId { get; set; } 
        public bool MatchIsFinish { get; set; }
    }
}
