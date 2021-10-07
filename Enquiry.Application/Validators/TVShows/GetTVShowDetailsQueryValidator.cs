using Enquiry.Application.Queries;
using FluentValidation;

namespace MoviesGallery.Core.Validators
{
    public class GetTVShowDetailsQueryValidator : AbstractValidator<GetTVShowDetailsQuery>
    {
        public GetTVShowDetailsQueryValidator()
        {
            RuleFor(x => x.ApiKey).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Query).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Equal("tv");
            RuleFor(x => x.ShowId).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0);
        }
    }
}
