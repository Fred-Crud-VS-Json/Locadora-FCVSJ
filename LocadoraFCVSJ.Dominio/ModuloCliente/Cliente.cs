using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public Cliente()
        {
        }

        public Cliente(string nome, string dado, string endereco, string tipo, string cnh, string email, string telefone)
        {
            Nome = nome;
            Dado = dado;
            Endereco = endereco;
            Tipo = tipo;
            CNH = cnh;
            Telefone = telefone;
            Email = email;
        }

        public string Nome { get; set; }
        public string Dado { get; set; }
        public string Endereco { get; set; }
        public string Tipo { get; set; }
        public string CNH { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   Nome == cliente.Nome &&
                   Dado == cliente.Dado &&
                   Endereco == cliente.Endereco &&
                   Tipo == cliente.Tipo &&
                   CNH == cliente.CNH &&
                   Telefone == cliente.Telefone &&
                   Email == cliente.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Dado, Endereco, Tipo, CNH, Telefone, Email);
        }
    }
}
