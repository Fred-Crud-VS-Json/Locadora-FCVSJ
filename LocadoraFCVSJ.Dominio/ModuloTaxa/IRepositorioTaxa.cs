using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorio<Taxa>
    {
        Taxa? SelecionarPorNome(string nome);
    }
}