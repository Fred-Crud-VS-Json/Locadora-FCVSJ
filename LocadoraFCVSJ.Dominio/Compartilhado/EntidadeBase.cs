namespace LocadoraFCVSJ.Dominio.Compartilhado
{
    public class EntidadeBase<T>
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
    }
}