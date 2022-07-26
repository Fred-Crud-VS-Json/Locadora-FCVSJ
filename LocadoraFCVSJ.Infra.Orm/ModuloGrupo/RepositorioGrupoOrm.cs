using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFCVSJ.Infra.Orm.ModuloGrupo
{
    public class RepositorioGrupoOrm : RepositorioBaseOrm<Grupo>, IRepositorioGrupo
    {
        private DbSet<Grupo> Grupos { get; }

        public RepositorioGrupoOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
            Grupos = _dbSet;
        }

        public Grupo? SelecionarGrupoPorNome(string nome)
        {
            return Grupos.FirstOrDefault(g => g.Nome == nome);
        }
    }
}