using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TY.LinkConverter.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSentry("https://23bb8e882fb146128890a674e1e801d9@o254391.ingest.sentry.io/5782642");
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}