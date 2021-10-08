using Gallery.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Application.Commands
{
    public class AddTVShowCommand : IRequest<TVShowToAdd>
    {
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public string OriginCountry { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public List<string> Genres { get; set; }
    }
}
