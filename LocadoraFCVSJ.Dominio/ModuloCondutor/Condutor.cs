using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;

namespace LocadoraFCVSJ.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string? CNPJ { get; set; }
        public string CNH { get; set; }
        public DateTime ValidadeCnh { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public UF? UF { get; set; }
        public string? Complemento { get; set; }
        public string Rua { get; set; }
        public Cliente Cliente { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Condutor condutor &&
                   Id.Equals(condutor.Id) &&
                   Nome == condutor.Nome &&
                   CPF == condutor.CPF &&
                   CNPJ == condutor.CNPJ &&
                   CNH == condutor.CNH &&
                   ValidadeCnh == condutor.ValidadeCnh &&
                   Telefone == condutor.Telefone &&
                   Email == condutor.Email &&
                   Cidade == condutor.Cidade &&
                   CEP == condutor.CEP &&
                   Numero == condutor.Numero &&
                   Bairro == condutor.Bairro &&
                   UF == condutor.UF &&
                   Complemento == condutor.Complemento &&
                   Rua == condutor.Rua &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(CPF);
            hash.Add(CNPJ);
            hash.Add(CNH);
            hash.Add(ValidadeCnh);
            hash.Add(Telefone);
            hash.Add(Email);
            hash.Add(Cidade);
            hash.Add(CEP);
            hash.Add(Numero);
            hash.Add(Bairro);
            hash.Add(UF);
            hash.Add(Complemento);
            hash.Add(Rua);
            hash.Add(Cliente);
            return hash.ToHashCode();
        }

        public override string? ToString()
        {
            return Nome;
        }
    }
}