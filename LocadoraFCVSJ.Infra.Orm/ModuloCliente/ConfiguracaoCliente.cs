using LocadoraFCVSJ.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraFCVSJ.Infra.Orm.ModuloCliente
{
    public class ConfiguracaoCliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBClienteOrm");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.CPF).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.CNPJ).HasColumnType("varchar(300)");
            builder.Property(x => x.CNH).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Cidade).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.CEP).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Rua).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Numero).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Bairro).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.UF).HasConversion<int>().IsRequired();
            builder.Property(x => x.Complemento).HasColumnType("varchar(300)").IsRequired();
        }
    }
}
