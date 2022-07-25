using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloTaxa;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorio<Taxa>
    {
        Taxa? SelecionarPropriedade<T>(string query, string parametro, T propriedade);
    }
}