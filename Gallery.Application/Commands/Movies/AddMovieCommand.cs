using Gallery.Domain;
using Gallery.Domain.AggregatesModel.MovieAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Application.Commands
{
    public class AddMovieCommand : IRequest<Movie>
    {
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public string OriginCountry { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public List<string> Genres { get; set; }
        //private string ApiKey { get; set; }

        //public string GetApiKey()
        //{
        //    return ApiKey;
        //}

        //public void SetApiKey(string apiKey)
        //{
        //    ApiKey = apiKey;
        //}
    }
}
