using Enquiry.Application.Queries;
using FluentValidation;

namespace Enquiry.Application.Validators
{
    public class GetTopRatedMoviesQueryValidator : AbstractValidator<GetTopRatedMoviesQuery>
    {
        public GetTopRatedMoviesQueryValidator()
        {
            RuleFor(x => x.ApiKey).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Query).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Equal("movie/top_rated");
            RuleFor(x => x.Page).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Equal(1);
        }
    }
}
