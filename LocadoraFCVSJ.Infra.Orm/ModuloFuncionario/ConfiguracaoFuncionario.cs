using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocadoraFCVSJ.Dominio.Compartilhado.Enums;

namespace LocadoraFCVSJ.Infra.Orm.ModuloFuncionario
{
    public class ConfiguracaoFuncionario : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionarioOrm");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Usuario).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Salario).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DataAdmissao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.NivelAcesso).HasConversion<int>().IsRequired();
        }
    }
}
