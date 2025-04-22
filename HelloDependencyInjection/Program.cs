using HelloDependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HelloDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = RegisterTypes();

            // Die Methode GetRequiredService() ist hier nur exemplarisch und werden wir
            // in unseren Web-Applikationen so NIE verwenden!
            // Die Abhangigkeit wird immer ueber den Konstruktor aufgeloest
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
            // Die ServiceCollection wird i. d. R. von der Applikation bereit gestellt und
            // ist dafuer da um die notwenidgen Services registrieren zu koennen
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
