using System.Threading.Tasks;
using Gallery.Application.Commands;
using Gallery.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TVShowsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TVShowsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "tv-shows-query")] string tv_shows_query,
            int id)
        {
            var query = new GetTVShowDetailsQuery
            {
                ApiKey = api_key,
                Query = tv_shows_query,
                ShowId = id,
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Add([FromBody] AddTVShowCommand tvShowCommand)
        {
            var result = await _mediator.Send(tvShowCommand);

            return Ok(result);
        }

        [HttpGet]
        [Route("top-rated")]
        public async Task<IActionResult> GetTopRated(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "tv-shows-query")] string tv_shows_query)
        {
            var query = new GetTopRatedTVShowsQuery
            {
                ApiKey = api_key,
                Query = tv_shows_query,
                Page = 1,
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("genre/{id}")]
        public async Task<IActionResult> GetByGenre(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "tv-shows-query")] string tv_shows_query,
            [FromQuery(Name = "page")] int page,
            int id)
        {
            var query = new GetTVShowsByGenreQuery
            {
                ApiKey = api_key,
                Query = tv_shows_query,
                Page = page,
                GenreId = id,
            };

            var result = await _mediator.Send(query);

            var command = new AddTVShowsListCommand
            {
                TvShows = result
            };

            return await AddList(command);
        }

        [HttpGet]
        [Route("genre/{id}/top-rated")]
        public async Task<IActionResult> GetTopRatedByGenre(
            [FromHeader(Name = "api-key")] string api_key, 
            [FromQuery(Name = "tv-shows-query")] string tv_shows_query,
            int id)
        {
            var query = new GetTopRatedTVShowsByGenreQuery
            {
                ApiKey = api_key,
                Query = tv_shows_query,
                Page = 1,
                GenreId = id,
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("new-list")]
        public async Task<IActionResult> AddList([FromBody] AddTVShowsListCommand tvShowsListCommand)
        {
            var result = await _mediator.Send(tvShowsListCommand);

            return Ok(result);
        }
    }
}