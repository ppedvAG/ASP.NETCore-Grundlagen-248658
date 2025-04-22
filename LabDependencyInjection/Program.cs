
using Lab002_DependencyInjection.Services;

namespace LabDependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IOperationSingleton, OperationService>();
            builder.Services.AddScoped<IOperationScoped, OperationService>();
            builder.Services.AddTransient<IOperationTransient, OperationService>();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
