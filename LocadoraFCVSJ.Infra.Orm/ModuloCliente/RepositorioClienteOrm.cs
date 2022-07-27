using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFCVSJ.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : RepositorioBaseOrm<Cliente>, IRepositorioCliente
    {
        private DbSet<Cliente> Cliente { get; }

        public RepositorioClienteOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
            Cliente = _dbSet;
        }

        public Cliente? SelecionarPorCnh(string cnh)
        {
            return Cliente.FirstOrDefault(t => t.CNH == cnh);
        }

        public Cliente? SelecionarPorCnpj(string cnpj)
        {
            return Cliente.FirstOrDefault(t => t.CNPJ == cnpj);
        }

        public Cliente? SelecionarPorCpf(string cpf)
        {
            return Cliente.FirstOrDefault(t => t.CPF == cpf);
        }

        public Cliente? SelecionarPorEmail(string email)
        {
            return Cliente.FirstOrDefault(t => t.Email == email);
        }

        public Cliente? SelecionarPorTelefone(string telefone)
        {
            return Cliente.FirstOrDefault(t => t.Telefone == telefone);
        }
    }
}
