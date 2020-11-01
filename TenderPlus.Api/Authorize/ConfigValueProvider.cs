using Microsoft.Extensions.Configuration;
using System.IO;

namespace TenderPlus.Api.Authorize
{
    public static class ConfigValueProvider
    {
        private static readonly IConfigurationRoot Configuration;
        static ConfigValueProvider()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
        public static string Get(string name)
        {
            if (name == "Auth")
            {
                return Configuration.GetSection("Tokenauthentication").GetSection("IsActive").Value.ToString();

            }
            return Configuration[name];
        }
    }
}
