using LocadoraFCVSJ.Dominio.Compartilhado;
using System;

namespace LocadoraFCVSJ.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public Funcionario()
        {
        }

        public Funcionario(string nome, string login, string senha, decimal salario, DateTime dataAdmissao, int nivelAcesso)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Salario = salario;
            DataAdmissao = dataAdmissao;
            NivelAcesso = nivelAcesso;
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public int NivelAcesso { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Login == funcionario.Login &&
                   Senha == funcionario.Senha &&
                   Salario == funcionario.Salario &&
                   DataAdmissao == funcionario.DataAdmissao &&
                   NivelAcesso == funcionario.NivelAcesso;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Login, Senha, Salario, DataAdmissao, NivelAcesso);
        }
    }
}
