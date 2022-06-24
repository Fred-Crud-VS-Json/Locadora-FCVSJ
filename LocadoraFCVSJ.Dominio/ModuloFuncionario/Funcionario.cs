using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public NivelAcessoEnum NivelAcesso { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Usuario == funcionario.Usuario &&
                   Senha == funcionario.Senha &&
                   Salario == funcionario.Salario &&
                   DataAdmissao == funcionario.DataAdmissao &&
                   NivelAcesso == funcionario.NivelAcesso;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Usuario, Senha, Salario, DataAdmissao, NivelAcesso);
        }

        public override string ToString()
        {
            return Nome + " - " + Usuario + " - " + Senha + " - " + Salario + " - " 
                + DataAdmissao + " - " + NivelAcesso;
        }
    }
}
