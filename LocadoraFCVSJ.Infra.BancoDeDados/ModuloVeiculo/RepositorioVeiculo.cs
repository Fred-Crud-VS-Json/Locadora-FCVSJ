

using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo
{
    public class RepositorioVeiculo : RepositorioBase<Veiculo, MapeadorVeiculo>, IRepositorioVeiculo
    {
        protected override string QueryInserir => throw new NotImplementedException();

        protected override string QueryEditar => throw new NotImplementedException();

        protected override string QueryExcluir => throw new NotImplementedException();

        protected override string QuerySelecionarPorId => throw new NotImplementedException();

        protected override string QuerySelecionarTodos => throw new NotImplementedException();

        public Veiculo? SelecionarPropriedade<T>(string query, string parametro, T propriedade)
        {
            throw new NotImplementedException();
        }
    }
}
