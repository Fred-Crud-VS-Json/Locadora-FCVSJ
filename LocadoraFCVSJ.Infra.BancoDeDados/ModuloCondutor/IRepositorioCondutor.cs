using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCondutor;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor? SelecionarPropriedade<T>(string query, string parametro, T propriedade);
    }
}
