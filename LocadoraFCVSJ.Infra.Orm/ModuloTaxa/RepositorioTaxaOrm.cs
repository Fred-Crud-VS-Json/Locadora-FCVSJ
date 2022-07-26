using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFCVSJ.Infra.Orm.ModuloTaxa
{
    public class RepositorioTaxaOrm : RepositorioBaseOrm<Taxa>, IRepositorioTaxa
    {
        private DbSet<Taxa> Taxas { get; }

        public RepositorioTaxaOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
            Taxas = _dbSet;
        }

        public Taxa? SelecionarPorNome(string nome)
        {
            return Taxas.FirstOrDefault(t => t.Nome == nome);
        }
    }
}