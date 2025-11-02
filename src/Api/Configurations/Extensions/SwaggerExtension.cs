namespace Api.Configurations.Extensions;

public static class SwaggerExtension
{
    public static WebApplication UseApiSwagger(this WebApplication app)
    {
        if (app.Environment.EnvironmentName is not ("Local" or "Development")) return app;

        app.UseDeveloperExceptionPage();
        app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "Open API V1"); });

        return app;
    }
}