﻿namespace HelloDependencyInjection.Services
{
    public class CurrentTimeService : ITimeService
    {
        public string GetTime()
        {
            return DateTime.Now.ToLongTimeString();
        }
    }
}
