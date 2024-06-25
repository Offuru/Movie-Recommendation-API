using Core.Services;
using Database.Context;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;
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
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<MovieRecommendationDbContext>();
            services.AddScoped<DbContext, MovieRecommendationDbContext>();

            services.AddScoped<UsersRepository>();
            services.AddScoped<MovieRepository>();
            services.AddScoped<ReviewsRepository>();
        }
    }
}
