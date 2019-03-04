using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CondominioMaster.Infra.Data.Mappings
{
    public class ImovelMapping : IEntityTypeConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.StatusRegistro)
               .HasColumnType("varchar(10)")
               .IsRequired();

            builder.Property(e => e.DataIncluiRegistro)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(e => e.NumeroPorta)
                .HasColumnType("varchar(10)")
                .IsRequired();
            
            builder.Property(e => e.Identificador)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(c => c.Edificacao)
                 .WithMany(e => e.Imoveis)
                 .HasForeignKey(c => c.IdEdificacao);

            builder.HasOne(e => e.Pessoa)
                .WithMany(e => e.Imoveis)
                .HasForeignKey(e => e.IdPessoaFinanceiro);

            builder.Ignore(e => e.ListaErros);

            builder.ToTable("Imovel");
        }
    }
}
