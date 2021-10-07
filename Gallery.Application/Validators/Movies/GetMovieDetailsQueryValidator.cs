using Gallery.Application.Queries;
using FluentValidation;

namespace Gallery.Application.Validators
{
    public class GetMovieDetailsQueryValidator : AbstractValidator<GetMovieDetailsQuery>
    {
        public GetMovieDetailsQueryValidator()
        {
            RuleFor(x => x.ApiKey).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Query).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Equal("movie");
            RuleFor(x => x.ShowId).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0);
        }
    }
}
