using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraFCVSJ.Infra.Orm.ModuloLocacao
{
    public class ConfiguracaoLocacao : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLocacaoOrm");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.Cliente).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Condutor).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Grupo).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Veiculo).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.PlanoDeCobranca).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.DataLocacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DataDevolucao).HasColumnType("datetime").IsRequired();
            builder.HasOne(x => x.Taxa).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.PrecoEstimado).HasColumnType("decimal(18,2)").IsRequired();
        }
    }
}
