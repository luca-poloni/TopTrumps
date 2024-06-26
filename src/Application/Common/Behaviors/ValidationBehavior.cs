using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                if (context != default)
                {
                    var validationResults = await ValidationResults(context, cancellationToken);

                    if (validationResults != default)
                    {
                        var failures = Failures(validationResults);

                        if (failures != default && failures.Count > 0)
                        {
                            var message = FailureMessage(failures);

                            if (!string.IsNullOrWhiteSpace(message))
                                throw new ArgumentException(message);
                        }
                    }

                }
            }

            return await next();
        }

        private async Task<ValidationResult[]> ValidationResults(ValidationContext<TRequest> context, CancellationToken cancellationToken)
        {
            return await Task.WhenAll(
                validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));
        }

        private static List<ValidationFailure> Failures(ValidationResult[] validationResults)
        {
            return validationResults
                .Where(r => r.Errors.Count > 0)
                .SelectMany(r => r.Errors)
                .ToList();
        }

        private static string FailureMessage(List<ValidationFailure> failures)
        {
            var message = string.Empty;

            foreach (var failure in failures)
                message += failure.ErrorMessage + Environment.NewLine;

            return message;
        }
    }
}
