using FluentValidation;
using Gallery.Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Application.Validators
{
    public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
    {
        public AddMovieCommandValidator()
        {
            //RuleFor(x => x.GetApiKey()).Cascade(CascadeMode.Stop).NotNull().NotEmpty().OverridePropertyName("ApiKey");

            RuleFor(x => x.Title).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.VoteAverage).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0).LessThanOrEqualTo(10);
            RuleFor(x => x.OriginCountry).Cascade(CascadeMode.Stop).NotNull().NotEmpty().Length(2);
            RuleFor(x => x.Overview).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.PosterPath).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(x => x.Genres).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
        }
    }
}
