using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloGrupo
{
    public class Grupo : EntidadeBase<Grupo>
    {
        public string Nome { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Grupo grupo &&
                   Id == grupo.Id &&
                   Nome == grupo.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }
    }
}