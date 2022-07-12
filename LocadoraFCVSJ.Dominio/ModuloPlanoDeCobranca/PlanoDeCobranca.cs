using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;

namespace LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {
        public Grupo Grupo { get; set; }
        public decimal PlanoDiario_ValorDiario { get; set; }
        public decimal PlanoDiario_ValorKm { get; set; }
        public decimal PlanoLivre_ValorDiario { get; set; }
        public decimal PlanoControlado_ValorDiario { get; set; }
        public decimal PlanoControlado_ValorKm { get; set; }
        public int PlanoControlado_LimiteKm { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PlanoDeCobranca cobranca &&
                   Id.Equals(cobranca.Id) &&
                   EqualityComparer<Grupo>.Default.Equals(Grupo, cobranca.Grupo) &&
                   PlanoDiario_ValorDiario == cobranca.PlanoDiario_ValorDiario &&
                   PlanoDiario_ValorKm == cobranca.PlanoDiario_ValorKm &&
                   PlanoLivre_ValorDiario == cobranca.PlanoLivre_ValorDiario &&
                   PlanoControlado_ValorDiario == cobranca.PlanoControlado_ValorDiario &&
                   PlanoControlado_ValorKm == cobranca.PlanoControlado_ValorKm &&
                   PlanoControlado_LimiteKm == cobranca.PlanoControlado_LimiteKm;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Grupo, PlanoDiario_ValorDiario, PlanoDiario_ValorKm, PlanoLivre_ValorDiario, PlanoControlado_ValorDiario, PlanoControlado_ValorKm, PlanoControlado_LimiteKm);
        }
    }
}