using Ardalis.SharedKernel;
using Domain.Game;
using Domain.Game.Specifications;
using MediatR;

namespace Application.UseCases.Feature.Commands.DeleteFeature
{
    internal class DeleteFeatureHandler(IRepository<GameAggregate> repository) : IRequestHandler<DeleteFeatureRequest>
    {
        public async Task Handle(DeleteFeatureRequest request, CancellationToken cancellationToken)
        {
            var game = await repository
                .FirstOrDefaultAsync(new GameByIdWithFeatureSpecification(request.GameId), cancellationToken) 
                    ?? throw new ArgumentException("Game not found to delete feature.");

            game.RemoveFeature(request.Id);

            await repository
                .SaveChangesAsync(cancellationToken);
        }
    }
}
