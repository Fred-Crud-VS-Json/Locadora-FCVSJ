using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloGrupo
{
    public interface IRepositorioGrupo : IRepositorio<Grupo>
    {
        Grupo? SelecionarGrupoPorNome(string nome);
    }
}