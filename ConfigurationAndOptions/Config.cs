using Microsoft.Extensions.Configuration;

namespace ConfigurationAndOptions
{
    public class Config
    {
        private string GreetingMessage { get; }

        public Config(IConfiguration configuration)
        {
            var section = configuration.GetSection("Configurations:Greetings");
            
            if (section.GetValue<bool>("Enable"))
                GreetingMessage = section.GetValue<string>("Message");
        }

        public string ShowGreetingMessage()
        {
            return GreetingMessage;
        }
    }
}