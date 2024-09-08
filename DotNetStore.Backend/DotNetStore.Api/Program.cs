public class Anything
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.Use(async (context, next) =>
        {
            Console.WriteLine(context.Request.QueryString);
            await next(context);
            Console.WriteLine(context.Response.StatusCode);
        });

        app.MapGet("/hello-world", () =>
        {
            return "Hello World!";
        })
        .WithName("Hello World")
        .WithOpenApi();

        app.Run();
    }
}