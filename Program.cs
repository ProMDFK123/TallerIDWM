using api.src.Data;

using Microsoft.EntityFrameworkCore;

using Serilog;
Log.Logger = new LoggerConfiguration()

    .CreateLogger();
try
{
    Log.Information("starting server.");
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();
    builder.Services.AddDbContext<DataContext>(options => 
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithThreadId()
            .Enrich.WithMachineName();

    });

    var app = builder.Build();
    DbInitializer.InitDb(app);
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "server terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}