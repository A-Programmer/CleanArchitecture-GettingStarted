using Microsoft.Extensions.DependencyInjection;

namespace Project.Presentation.DependencyInjectionExtensionMethods;

public static class SwaggerDependencyInjection
{
    public static IServiceCollection RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            
        });

        return services;
    }
}