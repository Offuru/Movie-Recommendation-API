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
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<MovieRecommendationDbContext>();
            services.AddScoped<DbContext, MovieRecommendationDbContext>();

            services.AddScoped<UsersRepository>();
        }
    }
}
