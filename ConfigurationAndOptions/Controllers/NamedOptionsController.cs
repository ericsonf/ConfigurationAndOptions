using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationAndOptions.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NamedOptionsController : ControllerBase
    {
        private readonly bool _enableGreetings;
        private readonly string _messageGreetings;
        private readonly bool _enableWelcomeBack;
        private readonly string _messageWelcomeBack;

        /*
         * Utilizando uma classe que através da interface IOptionsMonitor nos permite utilizar as propriedades do appsettings.json de duas sessões
         * diferentes (desde que tenham mesmas propriedades) como propriedades de uma classe qualquer, além de se auto atualizar quando o
         * appsettings.json é alterado mesmo que em tempo de execução.
         */
        public NamedOptionsController(IOptionsMonitor<Configurations> optionsMonitor)
        {
            var greetingsConfig = optionsMonitor.Get(Configurations.Greetings);
            _enableGreetings = greetingsConfig.Enable;
            _messageGreetings = greetingsConfig.Message;

            var welcomeBackConfig = optionsMonitor.Get(Configurations.WelcomeBack);
            _enableWelcomeBack = welcomeBackConfig.Enable;
            _messageWelcomeBack = welcomeBackConfig.Message;
        }

        [HttpGet]
        [Route("")]
        public string Get()
        {
            return _enableGreetings ? $"{ _messageGreetings }" : string.Empty;
        }

        [HttpGet]
        [Route("{message}")]
        public string Get(string message)
        {
            return _enableWelcomeBack ? $"{ _messageWelcomeBack } { message }" : string.Empty;
        }
    }
}
