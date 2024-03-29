using Cocona;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

try
{
    var builder = CoconaApp.CreateBuilder();
// Configure Serilog
// Build configuration
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
        .Build();

// Configure Serilog using settings from appsettings.json
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

// Add Serilog to logging
    builder.Services.AddLogging(builder =>
    {
        builder.ClearProviders(); // Clear other logging providers
        builder.AddSerilog();
    });
    builder.Services.AddTransient<MyService>();
    var app = builder.Build();
    app.AddCommand((MyService myService) => { myService.Hello("Hello Konnichiwa!"); });
    app.Run();
}
catch(Exception exception)
{
    Console.WriteLine(exception.Message);
}


class MyService
{
    private readonly ILogger _logger;

    public MyService(ILogger<MyService> logger)
    {
        _logger = logger;
    }

    public void Hello(string message)
    {
        try
        {
            _logger.LogInformation(message);
        }
        catch (Exception x)
        {
            Console.WriteLine(x);
            throw;
        }
        
    }
}