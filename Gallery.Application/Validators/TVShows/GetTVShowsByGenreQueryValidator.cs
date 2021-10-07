using Gallery.Application.Queries;
using FluentValidation;

namespace Gallery.Core.Validators
{
    class GetTVShowsByGenreQueryValidator : AbstractValidator<GetTVShowsByGenreQuery>
    {
        public GetTVShowsByGenreQueryValidator()
        {
            RuleFor(x => x.ApiKey).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Query).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Equal("discover/tv");
            RuleFor(x => x.Page).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0);
            RuleFor(x => x.GenreId).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0);
        }
    }
}
