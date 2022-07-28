using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloLocacao;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFCVSJ.Infra.Orm.ModuloLocacao
{
    public class RepositorioLocacaoOrm : RepositorioBaseOrm<Locacao>, IRepositorioLocacao
    {
        private DbSet<Locacao> Locacao { get; }

        public RepositorioLocacaoOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
            Locacao = _dbSet;
        }

        public Locacao? SelecionarPorDataLocacao(DateTime dataLocacao)
        {
            return Locacao.FirstOrDefault(t => t.DataLocacao == dataLocacao);
        }
    }
}
