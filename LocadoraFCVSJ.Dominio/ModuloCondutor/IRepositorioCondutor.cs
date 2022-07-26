using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor? SelecionarPorCpf(string cpf);
        Condutor? SelecionarPorCnpj(string cnpj);
        Condutor? SelecionarPorTelefone(string telefone);
        Condutor? SelecionarPorEmail(string email);
        Condutor? SelecionarPorCnh(string cnh);
    }
}