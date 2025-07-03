using data;
using Domain.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infastructure.RepositoryImplementation;
using Microsoft.Extensions.DependencyInjection;

namespace Infastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Database services
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}