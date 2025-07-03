using Application.MappingImplementation;
using Application.MappingInterface;
using Application.UseCaseImplemetation;
using Application.UseCaseInterface;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookMapper, BookMapper>();

            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}