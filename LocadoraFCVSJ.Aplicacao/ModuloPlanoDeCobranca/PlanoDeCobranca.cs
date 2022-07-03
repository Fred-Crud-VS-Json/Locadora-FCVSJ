using LocadoraFCVSJ.Dominio.ModuloGrupo;

namespace LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca
{
    public class PlanoDeCobranca
    {
        public Grupo Grupo { get; set; }
        public decimal PlanoDiarioValorDiario { get; set; }
        public decimal PlanoDiarioValorKm { get; set; }
        public decimal PlanoLivreValorDiario { get; set; }
        public decimal PlanoControladoValorDiario { get; set; }
        public decimal PlanoControladoValorKm { get; set; }
        public int PlanoControladoLimiteKm { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is PlanoDeCobranca cobranca &&
                   EqualityComparer<Grupo>.Default.Equals(Grupo, cobranca.Grupo) &&
                   PlanoDiarioValorDiario == cobranca.PlanoDiarioValorDiario &&
                   PlanoDiarioValorKm == cobranca.PlanoDiarioValorKm &&
                   PlanoLivreValorDiario == cobranca.PlanoLivreValorDiario &&
                   PlanoControladoValorDiario == cobranca.PlanoControladoValorDiario &&
                   PlanoControladoValorKm == cobranca.PlanoControladoValorKm &&
                   PlanoControladoLimiteKm == cobranca.PlanoControladoLimiteKm;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Grupo, PlanoDiarioValorDiario, PlanoDiarioValorKm, PlanoLivreValorDiario, PlanoControladoValorDiario, PlanoControladoValorKm, PlanoControladoLimiteKm);
        }
    }
}