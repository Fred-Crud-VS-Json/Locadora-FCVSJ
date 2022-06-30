using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo
{
    public interface IRepositorioVeiculo : IRepositorio<Veiculo>
    {
        Veiculo? SelecionarPropriedade<T>(string query, string parametro, T propriedade);
    }
}
