using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFCVSJ.Infra.Orm.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobrancaOrm : RepositorioBaseOrm<PlanoDeCobranca>, IRepositorioPlanoDeCobranca
    {
        public DbSet<PlanoDeCobranca> Planos { get; set; }

        public RepositorioPlanoDeCobrancaOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
            Planos = _dbSet;
        }
    }
}