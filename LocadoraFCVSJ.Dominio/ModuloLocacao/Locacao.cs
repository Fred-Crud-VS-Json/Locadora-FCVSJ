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

       
    }
}
