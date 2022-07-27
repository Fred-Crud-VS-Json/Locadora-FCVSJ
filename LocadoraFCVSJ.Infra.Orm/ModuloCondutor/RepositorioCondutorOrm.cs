using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraFCVSJ.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm : RepositorioBaseOrm<Condutor>, IRepositorioCondutor
    {
        private DbSet<Condutor> Condutor { get; }
        public RepositorioCondutorOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
            Condutor = _dbSet;
        }

        public Condutor? SelecionarPorCnh(string cnh)
        {
            return Condutor.FirstOrDefault(t => t.CNH == cnh);
        }

        public Condutor? SelecionarPorCnpj(string cnpj)
        {
            return Condutor.FirstOrDefault(t => t.CNPJ == cnpj);
        }

        public Condutor? SelecionarPorCpf(string cpf)
        {
            return Condutor.FirstOrDefault(t => t.CPF == cpf);
        }

        public Condutor? SelecionarPorEmail(string email)
        {
            return Condutor.FirstOrDefault(t => t.Email == email);
        }

        public Condutor? SelecionarPorTelefone(string telefone)
        {
            return Condutor.FirstOrDefault(t => t.Telefone == telefone);
        }
    }
}
