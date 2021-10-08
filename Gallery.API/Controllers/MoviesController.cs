using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gallery.Application.Commands;
using Gallery.Application.Dtos;
using Gallery.Application.Queries;
using Gallery.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(
            [FromHeader(Name = "api-key")] string api_key,
            [FromQuery(Name = "movies-query")] string movies_query,
            int id)
        {
            var query = new GetMovieDetailsQuery
            {
                ApiKey = api_key,
                Query = movies_query,
                ShowId = id,
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Add([FromBody] AddMovieCommand movieCommand)
        {
            var result = await _mediator.Send(movieCommand);

            return Ok(result);
        }

        [HttpGet]
        [Route("top-rated")]
        public async Task<IActionResult> GetTopRated(
            [FromHeader(Name = "api-key")] string api_key,
            [FromQuery(Name = "movies-query")] string movies_query)
        {
            var query = new GetTopRatedMoviesQuery
            {
                ApiKey = api_key,
                Query = movies_query,
                Page = 1
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("genre/{id}")]
        public async Task<IActionResult> GetByGenre(
            [FromHeader(Name = "api-key")] string api_key,
            [FromQuery(Name = "movies-query")] string movies_query,
            [FromQuery(Name = "page")] int page,
            int id)
        {
            var query = new GetMoviesByGenreQuery
            {
                ApiKey = api_key,
                Query = movies_query,
                Page = page,
                GenreId = id,
            };

            var result = await _mediator.Send(query);

            var command = new AddMoviesListCommand
            {
                Movies = result
            };

            return await AddList(command);
        }

        [HttpGet]
        [Route("genre/{id}/top-rated")]
        public async Task<IActionResult> GetTopRatedByGenre(
            [FromHeader(Name = "api-key")] string api_key,
            [FromQuery(Name = "movies-query")] string movies_query,
            int id)
        {
            var query = new GetTopRatedMoviesByGenreQuery
            {
                ApiKey = api_key,
                Query = movies_query,
                Page = 1,
                GenreId = id,
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("new-list")]
        public async Task<IActionResult> AddList([FromBody] AddMoviesListCommand moviesListCommand)
        {
            var result = await _mediator.Send(moviesListCommand);

            return Ok(result);
        }
    }
}