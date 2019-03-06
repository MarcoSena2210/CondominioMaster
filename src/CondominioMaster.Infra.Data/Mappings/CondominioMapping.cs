using CondominioMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioMaster.Infra.Data.Mappings
{
    public class CondominioMapping : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.StatusRegistro)
               .HasColumnType("varchar(10)")
               .IsRequired();

            builder.Property(c => c.DataIncluiRegistro)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(c => c.Apelido)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.OwnsOne(c => c.CPFCNPJ, cpfcnpj =>   //OwnsOne, sempre trata objetos complexo (VO)
            {
                cpfcnpj.Property(c => c.Numero)                   //no objeto complexo o nome é numero
                    .IsRequired()                                               //E requerido
                    .HasColumnName("CpfCnpj")                     //Nome da coluna
                    .HasColumnType("varchar(14)");                 //tamanho 14

                cpfcnpj.HasIndex(c => c.Numero).IsUnique();  //cria um indice unico
            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("varchar(100)");

            });

            builder.OwnsOne(c => c.Endereco, ender =>
            {
                ender.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("Endereco")
                    .HasColumnType("varchar(100)");

                ender.Property(e => e.Bairro)
                   .HasColumnName("Bairro")
                   .HasColumnType("varchar(30)");

                ender.Property(e => e.Cidade)
                   .HasColumnName("Cidade")
                   .IsRequired()
                   .HasColumnType("varchar(30)");
            });

            builder.OwnsOne(f => f.Endereco).OwnsOne(u => u.UF, uf =>
            {
                uf.Property(e => e.UF)
                    .HasColumnName("UF")
                    .HasColumnType("varchar(2)");
            });

            builder.OwnsOne(c => c.Endereco).OwnsOne(c => c.CEP, cep =>
            {
                cep.Property(e => e.Codigo)
                    .HasColumnName("CEP")
                    .HasColumnType("varchar(8)");

                cep.Ignore(c => c.Endereco);
                cep.Ignore(c => c.Bairro);
                cep.Ignore(c => c.Cidade);
                cep.Ignore(c => c.UF);
            });

            builder.HasOne(p => p.Empresa)
           .WithMany(f => f.Condominio)
           .HasForeignKey(p => p.IdEmpresa);
                       
            builder.Ignore(c => c.ListaErros);
            builder.ToTable("Condominio");

        }
    }
}