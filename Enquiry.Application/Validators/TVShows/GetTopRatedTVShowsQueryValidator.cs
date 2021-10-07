using Enquiry.Application.Queries;
using FluentValidation;

namespace Enquiry.Application.Validators
{
    public class GetTopRatedTVShowsQueryValidator : AbstractValidator<GetTopRatedTVShowsQuery>
    {
        public GetTopRatedTVShowsQueryValidator()
        {
            RuleFor(x => x.ApiKey).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Query).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Equal("tv/top_rated");
            RuleFor(x => x.Page).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Equal(1);
        }
    }
}
