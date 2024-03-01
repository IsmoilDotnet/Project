using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Abstractions;
using Project.Infrastructure.Persistance;
using Project.Infrastructure.Repositories;

namespace Project.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<ProjectDbContext>(options =>
            {
                options.UseNpgsql(conf.GetConnectionString("ProjectConnectionString"));
            });


            services.AddScoped<IUserRepo, UserRepo>();
            return services;
        }
    }
}
