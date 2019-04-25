using System;
using System.Reflection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace SpotifyBrowser.Host.Logger
{
    public class Logger
    {
        public static void Setup(string environmentName)
        {
            var assembly = Assembly.GetCallingAssembly();
            var logFileName = assembly.GetName().Name;
            var version = assembly.GetName().Version.ToString();

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == environmentName;

            var outputTemplate =
                "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}]} {Level}] [{Version}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}";

            var loggerConfiguration = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .MinimumLevel.Override("System", LogEventLevel.Information)
                    .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Debug)
                    .Enrich.FromLogContext()
                    .WriteTo.Console(outputTemplate: outputTemplate, theme: AnsiConsoleTheme.Literate)
                    .Enrich.WithProperty("Version", version)
                ;

            if (isDevelopment)
            {
                loggerConfiguration.WriteTo.File($"App_Data\\{logFileName}..log",
                    outputTemplate: outputTemplate,
                    rollingInterval: RollingInterval.Day);
            }
            else
            {
                loggerConfiguration.WriteTo.ApplicationInsightsEvents(
                    Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY"));
            }

            Log.Logger = loggerConfiguration.CreateLogger();
        }
    }
}