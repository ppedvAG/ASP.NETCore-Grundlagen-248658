
using Microsoft.Extensions.FileProviders;

namespace FileServer
{
    public class Program
    {
        public const string FILE_PATH = "files";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            PhysicalFileProvider provider = InitFileProvider(builder);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Zugriff auf Dateien auf dem Server ermoeglichen
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = provider,
                RequestPath = $"/{FILE_PATH}"
            });

            // Zum Anzeigen der Dateien im Browser
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = provider,
                RequestPath = $"/{FILE_PATH}"
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllerRoute("default", pattern: "{controller=files}");

            app.Run();
        }

        private static PhysicalFileProvider InitFileProvider(WebApplicationBuilder builder)
        {
            var rootPath = Path.Combine(builder.Environment.ContentRootPath, FILE_PATH);
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            var provider = new PhysicalFileProvider(rootPath);
            return provider;
        }
    }
}
