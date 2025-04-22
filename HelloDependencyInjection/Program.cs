using HelloDependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HelloDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = RegisterTypes();

            var timeService = serviceProvider.GetRequiredService<ITimeService>();
            var currentTime = timeService.GetTime();

            Console.WriteLine("Die aktuelle Zeit lautet: " + currentTime);

            var application = serviceProvider.GetRequiredService<IApplicationService>();
            application.RunApplication();

            Console.ReadKey();
        }

        /// <summary>
        /// Wird einmalig beim Start der Applikation aufgerufen wo alle Typen registriert werden
        /// </summary>
        /// <returns></returns>
        private static ServiceProvider RegisterTypes()
        {
            var container = new ServiceCollection();

            // Wir registrieren die konkrete Implementierung des Service gegen das Interface
            container.AddTransient<ITimeService, CurrentTimeService>();

            // Hier wird die vorherige Registrierung überschrieben und mit einer anderen Implementierung ersetzt
            container.AddTransient<ITimeService, UniversalTimeService>();

            // Service als Factory registrieren
            container.AddTransient<ITimeService>(c => new CustomTimeService("Als Factory registriert"));

             
            container.AddScoped<IApplicationService, ApplicationService>();

            var serviceProvider = container.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
