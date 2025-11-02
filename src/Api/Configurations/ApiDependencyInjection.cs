using Api.Configurations.Extensions;

namespace Api.Configurations;

public static class ApiDependencyInjection
{
    public static IServiceCollection ConfigureApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }

    public static WebApplication UseApi(this WebApplication app)
    {
        app.ApplyMigrations();

        app.UseRouting();
        app.MapControllers();
        app.MapOpenApi();
        app.UseApiSwagger();

        app.UseHttpsRedirection();

        return app;
    }
}
