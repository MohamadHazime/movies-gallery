using FluentValidation;
using Gallery.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Gallery.Application.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    if (!(exception is ValidationException validationException))
                    {
                        throw exception;
                    }

                    var errors = validationException.Errors.Select(err => new FailureValidationError
                    {
                        PropertyName = err.PropertyName,
                        ErrorMessage = err.ErrorMessage
                    });

                    var errorText = JsonSerializer.Serialize(errors);
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorText, Encoding.UTF8);
                });
            });
        }
    }
}
