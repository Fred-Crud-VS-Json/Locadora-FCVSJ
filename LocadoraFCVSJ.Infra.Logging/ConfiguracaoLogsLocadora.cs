using Microsoft.Extensions.Configuration;
using Serilog;

namespace LocadoraFCVSJ.Infra.Logging
{
    public class ConfiguracaoLogsLocadora
    {
        public static void ConfigurarLogger()
        {
            IConfigurationRoot? configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            string? diretorio = configuracao
                .GetSection("ConfiguracaoLogs")
                .GetSection("Diretorio")
                .Value;

            Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Debug()
                   .WriteTo.File(diretorio + "/log.txt",
               rollingInterval: RollingInterval.Day,
               outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                   .CreateLogger();
        }
    }
}