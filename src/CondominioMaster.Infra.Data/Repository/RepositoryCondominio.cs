using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Interfaces.Repository;
using CondominioMaster.Infra.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioMaster.Infra.Data.Repository
{
    public class RepositoryCondominio : Repository<Condominio>, IRepositoryCondominio
    {

        public RepositoryCondominio(ContextEFCondominioMaster context)
            : base(context)
        {

        }

       
        /* So foi possivel sobrescrever pq foi declarado  como virtual na classe pai(Repository)
         *, neste caso vamos usar o Dapper para as consultas com stringbuilder.
         * Melhora a performace consideravelmente.
         */
        public override IEnumerable<Condominio> ObterTodos()
        {
            /* Usando o Dapper */
           StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM condominio c
                             INNER JOIN empresa e ON c.IdEmpresa = e.Id
                            ORDER BY P.ID DESC
                          ");
            var condominios = Db.Database.GetDbConnection().Query<Condominio, Empresa, Condominio>(query.ToString(),
                (c, e) =>
                {
                    c.Empresa = e;
                    return c;
                });
            return condominios;
         }

        public override Condominio ObterPorId(int id)
        {
            /* Usando o Dapper */
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM condominio c 
                                    INNER JOIN empresa e ON c.IdEmpresa = e.Id
                                    WHERE c.Id = @uId 
                          ");
            var condominios = Db.Database.GetDbConnection().Query<Condominio, Empresa, Condominio>(query.ToString(),
                (c, e) =>
                {
                    c.Empresa = e;
                    return c;
                }, new { uID =id } );
            return condominios.FirstOrDefault();
        }
                 

        public Condominio ObterPorApelido(string apelido)
        {
            /*   através do Entity
             *   return Db.Empresa.AsNoTracking().FirstOrDefault(e => e.Apelido == apelido);
             *   ou
             *   return Db.Condominio.Include( e = e.empresa).FirstOrDefault(c => c.Apelido == apelido);
             *   */

            /* Usando o Dapper, melhor performace */
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM condominio c 
                                    INNER JOIN empresa e ON c.IdEmpresa = e.Id
                                    WHERE c.apelido  = @uAPELIDO 
                          ");
            var condominios = Db.Database.GetDbConnection().Query<Condominio, Empresa, Condominio>(query.ToString(),
                (c, e) =>
                {
                    c.Empresa = e;
                    return c;
                }, new { uAPELIDO  = apelido });
            return condominios.FirstOrDefault();

        }

        public Condominio ObterPorCpfCnpj(string cpfcnpj)
        {
            //  através do Entity
            //   return Db.Empresa.AsNoTracking().FirstOrDefault(e => e.CPFCNPJ.Numero == cpfcnpj);
     
            /* Usando o Dapper, melhor performace */
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM condominio c 
                                    INNER JOIN empresa e ON c.IdEmpresa = e.Id
                                    WHERE c.CpfCnpj  = @uCPFCNPJ
                          ");
            var condominios = Db.Database.GetDbConnection().Query<Condominio, Empresa, Condominio>(query.ToString(),
                (c, e) =>
                {
                    c.Empresa = e;
                    return c;
                }, new { uCPFCNPJ = cpfcnpj });
            return condominios.FirstOrDefault();

        }

        public Condominio ObterPorNome(string nome)
        {
            //   return Db.Empresa.AsNoTracking().FirstOrDefault(e => e.Nome == nome); //usando o entity
            /* Usando o Dapper, melhor performace para consulta */
            /* Usando o Dapper, melhor performace */
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM condominio c 
                                    INNER JOIN empresa e ON c.IdEmpresa = e.Id
                                    WHERE c.Nome = @uNome
                          ");
            var condominios = Db.Database.GetDbConnection().Query<Condominio, Empresa, Condominio>(query.ToString(),
                (c, e) =>
                {
                    c.Empresa = e;
                    return c;
                }, new { uNOME = nome });
            return condominios.FirstOrDefault();
        }

     }
}
