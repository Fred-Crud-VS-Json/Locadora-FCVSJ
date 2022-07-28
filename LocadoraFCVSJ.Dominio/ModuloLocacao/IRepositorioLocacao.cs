using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloLocacao
{
    public interface IRepositorioLocacao : IRepositorio<Locacao>
    {
        Locacao? SelecionarPorDataLocacao(string dataLocacao);

    }
}
