using Microsoft.AspNetCore.Hosting;
using SpotifyBrowser.Host.Logger;

namespace SpotifyBrowser.WriteStack.Api.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger.Setup(EnvironmentName.Development);

            SpotifyBrowser.Host.Host.WebHostBuilder
                .CreateWebHostBuilder(args)
                .UseStartup<Startup>()
                .Build().Run();
        }
    }
}
