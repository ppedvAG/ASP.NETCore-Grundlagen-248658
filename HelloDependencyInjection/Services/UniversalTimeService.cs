namespace HelloDependencyInjection.Services
{
    public class UniversalTimeService : ITimeService
    {
        public string GetTime()
        {
            return DateTime.UtcNow.ToLongTimeString();
        }
    }
}
