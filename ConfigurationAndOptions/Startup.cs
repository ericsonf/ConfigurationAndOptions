using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConfigurationAndOptions
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Seta as configurações do appsettings.json na classe Configurations
            services.Configure<Configurations>(Configuration.GetSection("Configurations:Greetings"));

            //Seta a validação das configurações do appsettings.json na classe ConfigurationsWithValidation
            services.AddOptions<ConfigurationsWithValidation>()
                .Bind(Configuration.GetSection("Configurations:WelcomeBack"))
                .ValidateDataAnnotations();

            //Seta as configurações das duas sessões do appsettings.json na classe Configurations (desde que tenham as mesmas propriedades)
            services.Configure<Configurations>(Configurations.Greetings, Configuration.GetSection("Configurations:Greetings"));
            services.Configure<Configurations>(Configurations.WelcomeBack, Configuration.GetSection("Configurations:WelcomeBack"));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}