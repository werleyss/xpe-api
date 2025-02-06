using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using xpe.Interfaces;
using xpe.Interfaces.Repositorys;
using xpe.Interfaces.Services;
using xpe.Notifications;
using xpe.Repositorys;
using xpe.Services;

namespace xpe.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        // Notificações
        services.AddScoped<INotifier, Notifier>();

        // Serviços 
        services.AddScoped<IProductService, ProductService>();

        // Repositórios
        services.AddScoped<IProductRepository, ProductRepository>();

        // Configuração do Swagger
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        return services;
    }
}