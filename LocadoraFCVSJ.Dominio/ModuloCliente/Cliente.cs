using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public Cliente()
        {
        }

        public Cliente(string nome, string cPF, string? cNPJ, string cNH, string telefone, string email, string cidade, string cEP, string numero, string bairro, UF uf, string? complemento, string rua)
        {
            Nome = nome;
            CPF = cPF;
            CNPJ = cNPJ;
            CNH = cNH;
            Telefone = telefone;
            Email = email;
            Cidade = cidade;
            CEP = cEP;
            Numero = numero;
            Bairro = bairro;
            UF = uf;
            Complemento = complemento;
            Rua = rua;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string? CNPJ { get; set; }
        public string CNH { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public UF? UF { get; set; }
        public string? Complemento { get; set; }
        public string Rua { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   Nome == cliente.Nome &&
                   CPF == cliente.CPF &&
                   CNPJ == cliente.CNPJ &&
                   CNH == cliente.CNH &&
                   Telefone == cliente.Telefone &&
                   Email == cliente.Email &&
                   Cidade == cliente.Cidade &&
                   CEP == cliente.CEP &&
                   Numero == cliente.Numero &&
                   Bairro == cliente.Bairro &&
                   UF == cliente.UF &&
                   Complemento == cliente.Complemento &&
                   Rua == cliente.Rua;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(CPF);
            hash.Add(CNPJ);
            hash.Add(CNH);
            hash.Add(Telefone);
            hash.Add(Email);
            hash.Add(Cidade);
            hash.Add(CEP);
            hash.Add(Numero);
            hash.Add(Bairro);
            hash.Add(UF);
            hash.Add(Complemento);
            hash.Add(Rua);
            return hash.ToHashCode();
        }
    }
}
