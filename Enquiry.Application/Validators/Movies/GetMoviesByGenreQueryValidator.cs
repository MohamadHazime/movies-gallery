using Enquiry.Application.Queries;
using FluentValidation;

namespace Enquiry.Application.Validators
{
    public class GetMoviesByGenreQueryValidator : AbstractValidator<GetMoviesByGenreQuery>
    {
        public GetMoviesByGenreQueryValidator()
        {
            RuleFor(x => x.ApiKey).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Query).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Equal("discover/movie");
            RuleFor(x => x.Page).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0);
            RuleFor(x => x.GenreId).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0);
        }
    }
}
