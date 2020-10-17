using System.ComponentModel.DataAnnotations;

namespace ConfigurationAndOptions
{
    public class ConfigurationsWithValidation
    {
        public bool Enable { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
