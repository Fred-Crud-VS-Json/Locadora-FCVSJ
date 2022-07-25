using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Cliente? SelecionarPropriedade<T>(string query, string parametro, T propriedade);
    }
}