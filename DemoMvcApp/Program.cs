using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Services;
using Microsoft.EntityFrameworkCore;

namespace DemoMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<ISimpleRecipeService, SimpleRecipeService>();

            // Unser RecipeService gegen die DB darf kein Singleton mehr sein!
            // Sonst wuerde der DbContext (und damit die DB-Verbindung) nie geschlossen werden.
            builder.Services.AddTransient<IRecipeService, RecipeService>();
            builder.Services.AddTransient<IFileService, RemoteFileService>();

            // Wir mappen die Einstellungen aus der appsettings.json nach FileServiceOptions
            var fileConfig = builder.Configuration.GetSection("FileServer");
            builder.Services.Configure<FileServiceOptions>(fileConfig);
            builder.Services.AddHttpClient();

            // Registrierungen fuer unsere Datenbank
            var connectionString = builder.Configuration.GetConnectionString("Default");
            //builder.Services.AddDbContext<DeliveryDbContext>(options => options.UseSqlServer(connectionString));
            // oder kuerzer
            builder.Services.AddSqlServer<DeliveryDbContext>(connectionString);

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
