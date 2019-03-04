using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CondominioMaster.Infra.Data.Context
{
    public class ContextEFCondominioMaster : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Edificacao> Edificacao { get; set; }
        public DbSet<Imovel> Imovel { get; set; }
        //public DbSet<ParametroEdificacao> ParametroEdificacao { get; set; }
        //public DbSet<Pessoa> Pessoa { get; set; }
        //public DbSet<PlanoContas> PlanoContas { get; set; }
        //public DbSet<TransacaoFinanceira> TransacaoFinanceira { get; set; }
        //public DbSet<TransacaoItem> TransacaoItem { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMapping());
            modelBuilder.ApplyConfiguration(new CondominioMapping());
            modelBuilder.ApplyConfiguration(new EdificacaoMapping());
            modelBuilder.ApplyConfiguration(new ImovelMapping());
            modelBuilder.Entity<Imovel>(entity => {
                entity.HasIndex(e => e.Identificador).IsUnique();
            });



            //modelBuilder.ApplyConfiguration(new ParametroEdificacaoMapping());
            modelBuilder.Entity<Pessoa>()
              .Ignore(p => p.ListaErros);
            modelBuilder.ApplyConfiguration(new PessoaMapping());
            //modelBuilder.ApplyConfiguration(new PlanoContasMapping());
            //modelBuilder.ApplyConfiguration(new TransacaoFinanceiraMapping());
            //modelBuilder.ApplyConfiguration(new TransacaoItemMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }


    }
}