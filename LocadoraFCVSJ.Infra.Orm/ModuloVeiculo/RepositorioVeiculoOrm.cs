using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFCVSJ.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : RepositorioBaseOrm<Veiculo>, IRepositorioVeiculo
    {
        private DbSet<Veiculo> Veiculos { get; }
        public RepositorioVeiculoOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
            Veiculos = _dbSet;
        }

        public Veiculo? SelecionarPorModelo(string modelo)
        {
            return Veiculos.FirstOrDefault(t => t.Modelo == modelo);
        }

        public Veiculo? SelecionarPorPlaca(string placa)
        {
            return Veiculos.FirstOrDefault(t => t.Placa == placa);
        }
    }
}
