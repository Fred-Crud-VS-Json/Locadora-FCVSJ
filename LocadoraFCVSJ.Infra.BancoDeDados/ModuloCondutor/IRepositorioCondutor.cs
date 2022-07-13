using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor? SelecionarPropriedade<T>(string query, string parametro, T propriedade);
    }
}
