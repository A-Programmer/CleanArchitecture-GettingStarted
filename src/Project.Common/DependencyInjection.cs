using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Project.Common;

public static class DependencyInjection
{
    public static IServiceCollection RegisterCommon(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication UseCommon(this WebApplication app)
    {
        return app;
    }
}