namespace DotNetStore.Api;

public static class Pipeline
{
    public static WebApplication UsePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment()) UseSwagger(app);

        app.UseHttpsRedirection().UseStaticFiles();

        app.UseAuthentication().UseAuthorization();

        app.UseRouting();
        app.MapControllers();

        return app;
    }

    private static void UseSwagger(WebApplication app)
    {
        app.UseSwagger()
           .UseSwaggerUI(config =>
            {
                config.DocumentTitle = "DotNetStore Web Api";
                config.InjectStylesheet("wwwroot/swagger.css");
            });
    }
}
