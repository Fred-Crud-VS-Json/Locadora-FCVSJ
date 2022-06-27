using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoCalculoTaxa? TipoCalculoTaxa { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Taxa taxa &&
                   Id == taxa.Id &&
                   Nome == taxa.Nome &&
                   Valor == taxa.Valor &&
                   TipoCalculoTaxa == taxa.TipoCalculoTaxa;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Valor, TipoCalculoTaxa);
        }
    }
}