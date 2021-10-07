using Gallery.Application.Queries;
using FluentValidation;

namespace Gallery.Application.Validators
{
    public class GetTopRatedTVShowsByGenreQueryValidator : AbstractValidator<GetTopRatedTVShowsByGenreQuery>
    {
        public GetTopRatedTVShowsByGenreQueryValidator()
        {
            RuleFor(x => x.ApiKey).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Query).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Equal("tv/top_rated");
            RuleFor(x => x.Page).Cascade(CascadeMode.Stop).NotNull().Equal(1);
            RuleFor(x => x.GenreId).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0);
        }
    }
}
