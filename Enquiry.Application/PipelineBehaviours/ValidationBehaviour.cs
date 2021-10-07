using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Enquiry.Application.PipelineBehaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("Start Validating Request: " + request.ToString());

            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (failures.Any())
            {
                _logger.LogInformation("Something went wrong.");

                foreach(var failure in failures)
                {
                    _logger.LogInformation("{Property} : {@Value}", failure.PropertyName, failure.ErrorMessage);
                }

                throw new ValidationException(failures);
            }

            _logger.LogInformation("Validation Succeeded");

            return await next();
        }
    }
}
