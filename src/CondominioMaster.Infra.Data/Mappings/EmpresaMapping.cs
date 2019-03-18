using CondominioMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioMaster.Infra.Data.Mappings
{
   //public class EmpresaMapping : IEntityTypeConfiguration<Empresa>

     public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
     {

        public   void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.StatusRegistro)
               .HasColumnType("varchar(10)")
               .IsRequired();
                    
            builder.Property(e => e.DataIncluiRegistro)
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(e => e.Apelido)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.OwnsOne(e => e.CPFCNPJ, cpfcnpj =>   //OwnsOne, sempre trata objetos complexo (VO)
            {
                cpfcnpj.Property(e => e.Numero)                   //no objeto complexo o nome é numero
                    .IsRequired()                                               //E requerido
                    .HasColumnName("CpfCnpj")                     //Nome da coluna
                    .HasColumnType("varchar(14)");                 //tamanho 14

                cpfcnpj.HasIndex(e => e.Numero).IsUnique();  //cria um indice unico
            });

            builder.OwnsOne(e => e.Email, email =>
            {
                email.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType("varchar(100)");

            });

            builder.OwnsOne(e => e.Endereco, ender =>
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

            builder.OwnsOne(e => e.Endereco).OwnsOne(e => e.CEP, cep =>
            {
                cep.Property(e => e.Codigo)
                    .HasColumnName("CEP")
                    .HasColumnType("varchar(8)");

                cep.Ignore(e => e.Endereco);
                cep.Ignore(e => e.Bairro);
                cep.Ignore(e => e.Cidade);
                cep.Ignore(e => e.UF);
            });
              
               builder.Ignore(e => e.ListaErros);

            builder.ToTable("Empresa");

        }
    }
}