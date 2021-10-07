using Enquiry.Application.Queries;
using FluentValidation;

namespace Enquiry.Application.Validators
{
    public class GetTopRatedMoviesByGenreQueryValidator : AbstractValidator<GetTopRatedMoviesByGenreQuery>
    {
        public GetTopRatedMoviesByGenreQueryValidator()
        {
            RuleFor(x => x.ApiKey).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Query).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Equal("movie/top_rated");
            RuleFor(x => x.Page).Cascade(CascadeMode.Stop).NotNull().Equal(1);
            RuleFor(x => x.GenreId).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0);
        }
    }
}
