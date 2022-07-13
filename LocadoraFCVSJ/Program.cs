using LocadoraFCVSJ.Infra.Logging;

namespace LocadoraFCVSJ
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ConfiguracaoLogsLocadora.ConfigurarLogger();
            ApplicationConfiguration.Initialize();
            Application.Run(new TelaPrincipal());
        }
    }
}