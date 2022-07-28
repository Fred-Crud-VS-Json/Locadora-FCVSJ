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
        public Guid ClienteId { get; set; }
        public Condutor Condutor { get; set; }
        public Guid CondutorId { get; set; }
        public Grupo Grupo { get; set; }
        public Guid GrupoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public Guid VeiculoId { get; set; }
        public PlanoDeCobranca PlanoDeCobranca { get; set; }
        public Guid PlanoDeCobrancaId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Taxa Taxa { get; set; }
        public Guid TaxaId { get; set; }
        public decimal PrecoEstimado { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   EqualityComparer<Condutor>.Default.Equals(Condutor, locacao.Condutor) &&
                   EqualityComparer<Grupo>.Default.Equals(Grupo, locacao.Grupo) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   EqualityComparer<PlanoDeCobranca>.Default.Equals(PlanoDeCobranca, locacao.PlanoDeCobranca) &&
                   DataLocacao == locacao.DataLocacao &&
                   DataDevolucao == locacao.DataDevolucao &&
                   EqualityComparer<Taxa>.Default.Equals(Taxa, locacao.Taxa) &&
                   PrecoEstimado == locacao.PrecoEstimado;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Cliente);
            hash.Add(Condutor);
            hash.Add(Grupo);
            hash.Add(Veiculo);
            hash.Add(PlanoDeCobranca);
            hash.Add(DataLocacao);
            hash.Add(DataDevolucao);
            hash.Add(Taxa);
            hash.Add(PrecoEstimado);
            return hash.ToHashCode();
        }
    }
}
