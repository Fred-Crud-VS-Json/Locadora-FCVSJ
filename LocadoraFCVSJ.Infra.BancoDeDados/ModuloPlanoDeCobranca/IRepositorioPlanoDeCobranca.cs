using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca
{
    public interface IRepositorioPlanoDeCobranca : IRepositorio<PlanoDeCobranca>
    {
        PlanoDeCobranca? SelecionarPropriedade<T>(string query, string parametro, T propriedade);
    }
}