using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Presentation.DependencyInjectionExtensionMethods;

namespace Project.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection RegisterPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.RegisterSwagger();

        return services;
    }

    public static WebApplication UsePresentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.MapControllers();
        
        return app;
    }
}