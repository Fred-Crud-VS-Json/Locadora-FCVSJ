using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo
{
    public interface IRepositorioGrupo : IRepositorio<Grupo>
    {
        Grupo? SelecionarPropriedade<T>(string parametro, T propriedade);
    }
}