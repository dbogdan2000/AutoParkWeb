using Microsoft.Extensions.Configuration;

namespace WebApplication
{
    public class AppConfig
    {
        public string ConnectionString { get; set; }

        public AppConfig(IConfiguration configuration)
        {
            configuration.Bind(this);
        }
    }
}