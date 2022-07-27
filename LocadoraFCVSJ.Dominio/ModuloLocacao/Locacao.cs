using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;

namespace LocadoraFCVSJ.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Cliente Cliente { get; set; }
        public Grupo Grupo { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Condutor Condutor { get; set; }
        public Veiculo Veiculo { get; set; }
        public Taxa Taxa { get; set; }
        public decimal precoEstimado { get; set; }
        public PlanoDeCobranca PlanoDeCobranca { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   EqualityComparer<Grupo>.Default.Equals(Grupo, locacao.Grupo) &&
                   DataLocacao == locacao.DataLocacao &&
                   DataDevolucao == locacao.DataDevolucao &&
                   EqualityComparer<Condutor>.Default.Equals(Condutor, locacao.Condutor) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   EqualityComparer<Taxa>.Default.Equals(Taxa, locacao.Taxa) &&
                   precoEstimado == locacao.precoEstimado &&
                   EqualityComparer<PlanoDeCobranca>.Default.Equals(PlanoDeCobranca, locacao.PlanoDeCobranca);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Cliente);
            hash.Add(Grupo);
            hash.Add(DataLocacao);
            hash.Add(DataDevolucao);
            hash.Add(Condutor);
            hash.Add(Veiculo);
            hash.Add(Taxa);
            hash.Add(precoEstimado);
            hash.Add(PlanoDeCobranca);
            return hash.ToHashCode();
        }
    }
}
