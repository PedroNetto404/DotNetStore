using DotNetStore.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services
       .AddApiServices();

await builder.Build()
             .UsePipeline()
             .RunAsync();