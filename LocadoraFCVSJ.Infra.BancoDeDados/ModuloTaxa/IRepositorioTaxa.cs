using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorio<Taxa>
    {
        Taxa? SelecionarPropriedade<T>(string query, string parametro, T propriedade);
    }
}