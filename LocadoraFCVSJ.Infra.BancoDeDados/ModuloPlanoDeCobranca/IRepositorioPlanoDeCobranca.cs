using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca
{
    public interface IRepositorioPlanoDeCobranca
    {
        PlanoDeCobranca? SelecionarPropriedade<T>(string query, string parametro, T propriedade);
    }
}