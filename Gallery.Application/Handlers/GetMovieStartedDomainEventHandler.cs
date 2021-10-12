using Gallery.Domain.Events;
using MediatR;
using System;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Gallery.Application.Commands;
using System.Collections.Generic;

namespace Gallery.Application.Handlers
{
    public class GetMovieStartedDomainEventHandler : INotificationHandler<GetMovieStartedDomainEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILoggerFactory _logger;

        public GetMovieStartedDomainEventHandler(ILoggerFactory logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Handle(GetMovieStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            var log = _logger.CreateLogger("Movie");

            log.LogInformation("Add movie to mongodb: " + notification.Movie.Id);

            var command = new AddMovieCommand
            {
                Title = notification.Movie.Title,
                VoteAverage = notification.Movie.VoteAverage,
                OriginCountry = notification.Movie.OriginalLanguage,
                Overview = notification.Movie.Overview,
                PosterPath = notification.Movie.PosterPath,
                Genres = new List<string>
                {
                    "Action"
                }
            };

            await _mediator.Send(command);
        }
    }
}
