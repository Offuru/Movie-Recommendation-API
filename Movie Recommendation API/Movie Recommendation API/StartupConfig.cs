using Core.Services;
using Database.Context;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace API
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<UsersService>();
            services.AddScoped<MovieService>();
            services.AddScoped<ReviewService>();
            services.AddScoped<AuthService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<MovieRecommendationDbContext>();
            services.AddScoped<DbContext, MovieRecommendationDbContext>();

            services.AddScoped<UsersRepository>();
            services.AddScoped<MovieRepository>();
            services.AddScoped<ReviewsRepository>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Move Recommendation API", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    }
                });
            });
        }
    }
}
