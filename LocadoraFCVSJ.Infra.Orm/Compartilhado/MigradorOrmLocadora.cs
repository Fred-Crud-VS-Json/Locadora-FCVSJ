using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraFCVSJ.Infra.Orm.Compartilhado
{
    public static class MigradorOrmLocadora
    {
        public static void Atualizar()
        {
            IConfigurationRoot configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            LocadoraOrmContext contexto = new(configuracao.GetConnectionString("SqlServer"));

            if (contexto.Database.GetPendingMigrations().Any())
                contexto.Database.Migrate();
        }
    }
}