namespace Application.UseCases.Round.Actions.PlayRound
{
    public record PlayRoundResponse
    {
        public Guid WinnerRoundPlayerId { get; set; } 
        public Guid? WinnerMatchPlayerId { get; set; }
    }
}
