using LocadoraFCVSJ.Dominio.Compartilhado.Excecoes;
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

        public void DesfazerAlteracoes() 
        { 
            var context = this; 
            var changedEntries = context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
            foreach (var entry in changedEntries) 
            { 
                switch (entry.State) 
                { 
                    case EntityState.Modified: 
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged; 
                        break;
                    
                    case EntityState.Added: 
                        entry.State = EntityState.Detached; 
                        break; 
                    
                    case EntityState.Deleted: 
                        entry.State = EntityState.Unchanged; 
                        break; 
                } 
            } 
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