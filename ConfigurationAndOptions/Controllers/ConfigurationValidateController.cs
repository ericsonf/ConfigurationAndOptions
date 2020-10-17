using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationAndOptions.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConfigurationValidateController : ControllerBase
    {
        private readonly ConfigurationsWithValidation _configurations;

        /*
         * Utilizando uma classe que através da interface IOptions nos permite utilizar as propriedades do appsettings.json
         * como propriedades de uma classe qualquer, porém validando se a propriedade existe no appsettings.json.
         */
        public ConfigurationValidateController(IOptions<ConfigurationsWithValidation> options)
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
