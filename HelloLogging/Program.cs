using Serilog;

namespace HelloLogging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Serilog konfigurieren
            Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("app.log", rollingInterval: RollingInterval.Day)
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            // Serilog benutzen und via Depedency Injection verfuegbar zu machen
            builder.Host.UseSerilog();


            var app = builder.Build();

            // Serilog eine Information schreiben lassen
            Serilog.Log.Information("Starting up");

            try
            {
                // Minimal API (ohne Controller zu definieren)
                app.MapGet("/", () => "Hello World!");
                app.MapGet("/error", () =>
                {
                    throw new InvalidOperationException("Hello Invalid Operation");
                });
                app.MapGet("/test", (ILogger<Program> logger) =>
                {
                    // Wir koennen hier auf die Dependency logger zugreifen, weil wir das in Zeile 19 registriert haben
                    logger.LogInformation("Hello test from test method");
                    return "Hello test";
                });

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                Log.Information("Shut down complete");
                Log.CloseAndFlush();
            }
        }
    }
}
