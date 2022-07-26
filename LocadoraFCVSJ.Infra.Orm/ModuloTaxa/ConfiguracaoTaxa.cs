using LocadoraFCVSJ.Dominio.Compartilhado.Enums;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraFCVSJ.Infra.Orm.ModuloTaxa
{
    public class ConfiguracaoTaxa : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TBTaxaOrm");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Valor).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.TipoCalculoTaxa).HasConversion<int>().IsRequired();
        }
    }
}