using LocadoraFCVSJ.Dominio.ModuloGrupo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraFCVSJ.Infra.Orm.ModuloGrupo
{
    public class ConfiguracaoGrupo : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("TBGrupoOrm");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
        }
    }
}