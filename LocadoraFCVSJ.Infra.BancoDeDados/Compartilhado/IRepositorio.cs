using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        void Inserir(T registro);
        void Editar(T registro);
        void Excluir(T registro);
        List<T> SelecionarTodos();
        T? SelecionarPorId(int id);
    }
}