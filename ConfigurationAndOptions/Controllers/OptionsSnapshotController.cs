using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationAndOptions.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OptionsSnapshotController : ControllerBase
    {
        private readonly Configurations _configurations;

        /*
         * Utilizando uma classe que através da interface IOptionsSnapshot nos permite utilizar as propriedades do appsettings.json
         * como propriedades de uma classe qualquer além de se auto atualizar quando o appsettings.json é alterado mesmo em tempo de execução.
         */
        public OptionsSnapshotController(IOptionsSnapshot<Configurations> optionsSnapshot)
        {
            _configurations = optionsSnapshot.Value;
        }

        [HttpGet]
        [Route("")]
        public string Get()
        {
            return _configurations.Enable ? $"{ _configurations.Message }" : string.Empty;
        }
    }
}
