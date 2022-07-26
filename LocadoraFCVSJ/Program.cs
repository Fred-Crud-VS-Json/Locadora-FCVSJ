using LocadoraFCVSJ.Compartilhado.ServiceLocator;
using LocadoraFCVSJ.Infra.Logging;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;

namespace LocadoraFCVSJ
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            MigradorOrmLocadora.Atualizar();
            ConfiguracaoLogsLocadora.ConfigurarLogger();
            ApplicationConfiguration.Initialize();
            Application.Run(new TelaPrincipal(new ServiceLocatorComAutoFac()));
        }
    }
}