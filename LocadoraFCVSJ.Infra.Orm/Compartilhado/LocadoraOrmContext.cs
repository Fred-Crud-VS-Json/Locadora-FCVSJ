using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LocadoraFCVSJ.Infra.Orm.Compartilhado
{
    public class LocadoraOrmContext : DbContext, IContextoPersistencia
    {
        private readonly string _connectionString;

        public LocadoraOrmContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void GravarDados()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            ILoggerFactory loggerFactory = LoggerFactory.Create(x => x.AddSerilog(Log.Logger));
       
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocadoraOrmContext).Assembly);
        }
    }
}