namespace HelloDependencyInjection.Services
{
    public class CustomTimeService : ITimeService
    {
        private readonly string _message;

        public CustomTimeService(string message)
        {
            _message = message;
        }

        public string GetTime() 
        {
            return _message + "\t" + DateTime.UtcNow.ToLongTimeString();
        }
    }
}
