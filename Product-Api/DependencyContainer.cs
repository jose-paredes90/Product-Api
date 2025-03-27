using Product_Api.Domain.Repositories;
using Product_Api.Infrastructure.DataContext;
using Product_Api.Infrastructure.Repositories;
using System.Reflection;

namespace Product_Api
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Asegúrate de que MediatR esté correctamente instalado y configurado
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
