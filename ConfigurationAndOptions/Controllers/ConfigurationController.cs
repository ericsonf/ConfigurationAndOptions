using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConfigurationAndOptions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("")]
        public string Get()
        {
            //Utilizando uma classe para controlar o acesso as properties do appsettings.json através dos métodos GetSection e GetValue.
            var configuration = new Config(_configuration);
            return configuration.ShowGreetingMessage();
        }
        
        [HttpGet]
        [Route("{message}")]
        public string Get(string message)
        {
            //Utilizando uma classe que através do método Bind nos permite utilizar as propriedades do appsettings.json como propriedades de uma classe qualquer.
            var configurations = new Configurations();
            _configuration.Bind("Configurations:Greetings", configurations);
            return configurations.Enable ? $"{ configurations.Message } {message}" : string.Empty;
        }
    }
}