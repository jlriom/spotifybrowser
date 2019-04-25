using Microsoft.AspNetCore.Hosting;
using SpotifyBrowser.Host.Logger;

namespace SpotifyBrowser.IdP
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Logger.Setup(EnvironmentName.Development);

            Host.Host.WebHostBuilder
                .CreateWebHostBuilder(args)
                .UseStartup<Startup>()
                .Build().Run();
        }
    }
}
