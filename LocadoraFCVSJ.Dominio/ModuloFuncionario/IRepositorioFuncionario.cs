using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
        Funcionario? SelecionarPorUsuario(string usuario);
    }
}