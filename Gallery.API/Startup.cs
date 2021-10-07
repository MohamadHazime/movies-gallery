using Gallery.Application.Extensions;
using Gallery.Application.Helpers;
using Gallery.Application.PipelineBehaviours;
using Gallery.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System;
using Domain.Models;
using Gallery.Shared.Dtos;

namespace Gallery.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MongoDBSettings>(Configuration.GetSection("MoviesDBSettings"));

            services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                return new MongoClient(Configuration["ConnectionString"]);
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddSingleton<IMongoShowsRepository<MovieDetailsDTO>, MongoMoviesRepository>();
            services.AddSingleton<IMongoShowsRepository<TVShowDetailsDTO>, MongoTVShowsRepository>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoviesGallery.API", Version = "v1" });
            });

            var assembly = AppDomain.CurrentDomain.Load("Gallery.Application");
            services.AddMediatR(assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            services.AddValidatorsFromAssembly(assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoviesGallery.API v1"));
            }

            app.UseFluentValidationExceptionHandler();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
