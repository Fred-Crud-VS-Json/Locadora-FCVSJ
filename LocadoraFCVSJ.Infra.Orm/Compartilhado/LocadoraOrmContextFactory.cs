using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LocadoraFCVSJ.Infra.Orm.Compartilhado
{
    public class LocadoraOrmContextFactory : IDesignTimeDbContextFactory<LocadoraOrmContext>
    {
        public LocadoraOrmContext CreateDbContext(string[] args)
        {
            IConfiguration configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            return new LocadoraOrmContext(configuracao.GetConnectionString("SqlServer"));
        }
    }
}