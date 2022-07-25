using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
        Funcionario? SelecionarPropriedade<T>(string query, string parametro, T propriedade);
    }
}
