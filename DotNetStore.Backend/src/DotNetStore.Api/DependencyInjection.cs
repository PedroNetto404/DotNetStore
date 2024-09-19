using System.Text.Json;

namespace DotNetStore.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors();

        var controllerBuilder = services.AddControllers();
        controllerBuilder.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        });

        services.AddRouting(config =>
        {
            config.LowercaseUrls = true;
        });

        return services;
    }
}
