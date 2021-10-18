using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Report.API
{
    public class ReportDataCollector : IHostedService
    {
        private readonly ISubscriber _subscriber;
        private readonly IMemoryReportStorage _memory;

        public ReportDataCollector(ISubscriber subscriber, IMemoryReportStorage memory)
        {
            _subscriber = subscriber;
            _memory = memory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriber.Subscribe(ProcessMessage);

            return Task.CompletedTask;
        }

        private bool ProcessMessage(string message, IDictionary<string, object> headers)
        {
            var moviesList = JsonConvert.DeserializeObject<List<Movie>>(message);

            foreach(var movie in moviesList)
            {
                if(!_memory.Get().Any(r => r.Id == movie.Id))
                {
                    _memory.Add(new Report
                    {
                        Id = movie.Id,
                        Title = movie.Title
                    });
                }
            }
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
