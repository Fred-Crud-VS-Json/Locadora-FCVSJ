using LocadoraFCVSJ.Dominio.Compartilhado;

namespace LocadoraFCVSJ.Dominio.ModuloGrupo
{
    public class Grupo : EntidadeBase<Grupo>
    {
        public Grupo()
        {
        }

        public Grupo(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Grupo grupo &&
                   Id == grupo.Id &&
                   Nome == grupo.Nome;
        }

        public override string ToString()
        {
            return Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }
    }
}