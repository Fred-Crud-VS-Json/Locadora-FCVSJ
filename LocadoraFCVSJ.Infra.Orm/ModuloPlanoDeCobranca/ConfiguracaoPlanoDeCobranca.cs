using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraFCVSJ.Infra.Orm.ModuloPlanoDeCobranca
{
    public class ConfiguracaoPlanoDeCobranca : IEntityTypeConfiguration<PlanoDeCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
        {
            builder.ToTable("TBPlanoOrm");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.PlanoDiario_ValorDiario).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PlanoDiario_ValorKm).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PlanoLivre_ValorDiario).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PlanoControlado_ValorDiario).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PlanoControlado_ValorKm).HasColumnType("decimal(18,2)");
            builder.Property(x => x.PlanoControlado_LimiteKm).HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Grupo).WithOne().OnDelete(DeleteBehavior.Restrict);
        }
    }
}