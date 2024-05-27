namespace Project.WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection RegisterWebApi(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication UseWebApi(this WebApplication app)
    {
        return app;
    }
}