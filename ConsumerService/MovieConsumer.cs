using MassTransit;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Threading.Tasks;

namespace ConsumerService
{
    public class MovieConsumer : IConsumer<Movie>
    {
        private readonly ILogger<MovieConsumer> _logger;

        public MovieConsumer(ILogger<MovieConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Movie> context)
        {
            await Console.Out.WriteLineAsync(context.Message.Title);
            _logger.LogInformation($"Got new Message: {context.Message.Title}");
        }
    }
}