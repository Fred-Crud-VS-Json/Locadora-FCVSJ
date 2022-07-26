using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Cliente? SelecionarPorCpf(string cpf);
        Cliente? SelecionarPorCnpj(string cnpj);
        Cliente? SelecionarPorTelefone(string telefone);
        Cliente? SelecionarPorEmail(string email);
        Cliente? SelecionarPorCnh(string cnh);
    }
}