using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Cliente? SelecionarPropriedade<T>(string parametro, T propriedade);
    }
}
