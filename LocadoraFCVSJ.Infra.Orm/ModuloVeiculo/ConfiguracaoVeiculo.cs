using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraFCVSJ.Infra.Orm.ModuloVeiculo
{
    public class ConfiguracaoVeiculo : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVeiculoOrm");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Modelo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Marca).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("varchar(10)").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.CapacidadeTanque).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.TipoCombustivel).HasConversion<int>().IsRequired();
            builder.Property(x => x.Ano).HasColumnType("int").IsRequired();
            builder.Property(x => x.KmPercorrido).HasColumnType("int").IsRequired();
            builder.Property(x => x.Foto).HasColumnType("varbinary(max)").IsRequired();
        }
    }
}
