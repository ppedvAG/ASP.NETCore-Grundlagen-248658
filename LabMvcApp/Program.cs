using BusinessModel.Contracts;
using BusinessModel.Services;
using MovieStore.Contracts;
using MovieStore.Data;
using MovieStore.Services;

namespace LabMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<IMovieService, MovieService>();
            builder.Services.AddTransient<IFileService, RemoteFileService>();

            // Wir mappen die Einstellungen aus der appsettings.json nach FileServiceOptions
            var fileConfig = builder.Configuration.GetSection("FileServer");
            builder.Services.Configure<FileServiceOptions>(fileConfig);
            builder.Services.AddHttpClient();

            // Registrierungen fuer unsere Datenbank
            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddSqlServer<MovieDbContext>(connectionString);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
