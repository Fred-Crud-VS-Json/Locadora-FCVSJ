using LocadoraFCVSJ.Dominio.Compartilhado.Interfaces;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraFCVSJ.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : RepositorioBaseOrm<Funcionario>, IRepositorioFuncionario
    {
        private DbSet<Funcionario> Funcionario { get; }

        public RepositorioFuncionarioOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
            Funcionario = _dbSet;
        }

        public Funcionario? SelecionarPorUsuario(string usuario)
        {
            return Funcionario.FirstOrDefault(t => t.Usuario == usuario);
        }
    }
}
