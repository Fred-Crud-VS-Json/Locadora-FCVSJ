using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo
{
    public interface IRepositorioGrupo : IRepositorio<Grupo>
    {
        Grupo? SelecionarPropriedade<T>(string query, string parametro, T propriedade);
    }
}