using Microsoft.Extensions.Configuration;

namespace TY.LinkConverter.Test.Helper
{
    public class ConfigurationHelper
    {
        public static IConfiguration Configuration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
        }
    }
}