namespace BlazorApp.Services
{
    public class GreetingService : IGrettingService
    {
        public string GetGreeting()
        {
            return "Hello from the GreetingService!";
        }
    }
}
