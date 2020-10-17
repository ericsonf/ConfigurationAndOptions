using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationAndOptions.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly Configurations _configurations;

        /*
         * Utilizando uma classe que através da interface IOptions nos permite utilizar as propriedades do appsettings.json
         * como propriedades de uma classe qualquer.
         */
        public OptionsController(IOptions<Configurations> options)
        {
            _configurations = options.Value;
        }

        [HttpGet]
        [Route("")]
        public string Get()
        {
            return _configurations.Enable ? $"{ _configurations.Message }" : string.Empty;
        }
    }
}
