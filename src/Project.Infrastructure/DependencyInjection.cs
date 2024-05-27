using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Models.Books;
using Project.Infrastructure.Data;
using Project.Infrastructure.Data.Repositories;

namespace Project.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite("Data Source=Books.db",
                x =>
                    x.MigrationsAssembly(AssemblyReference.Assembly.FullName));
        });

        services.AddScoped<IBooksRepository, BooksRepository>();
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
        
        return app;
    }
}