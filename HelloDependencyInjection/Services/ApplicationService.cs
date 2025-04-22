namespace HelloDependencyInjection.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ITimeService _timeService;

        // Wir holen uns hier die Dependency (Abhangigkeit) hier rein
        public ApplicationService(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public void RunApplication()
        {
            Console.WriteLine($"Hallo, die Zeit ist {_timeService.GetTime()}");
        }
    }
}
