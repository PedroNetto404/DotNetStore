using System.Text.Json;

public class Anything
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors();

        var controllerBuilder = builder.Services.AddControllers();
        controllerBuilder.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        });

        builder.Services.AddRouting(config =>
        {
            config.LowercaseUrls = true;
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(config =>
        {
            config.AllowAnyOrigin();
        });

        app.UseHttpsRedirection();

        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}