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
    public class RepositoryEmpresa : Repository<Empresa>, IRepositoryEmpresa
    {
        public RepositoryEmpresa(ContextEFCondominioMaster context)
            : base(context)
        {

        }

        /* So foi possivel sobrescrever pq foi declarado  como virtual na classe pai(Repository)
         *, neste caso vamos usar o Dapper para as consultas com stringbuilder.
         * Melhora a performace consideravelmente.
         */
        public override IEnumerable<Empresa> ObterTodos() {
            /* Usando o Dapper */
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM empresa ORDER BY id DESC");
             return Db.Database.GetDbConnection().Query<Empresa>(query.ToString());
         }

        public override Empresa ObterPorId(int id)
        {
            /* Usando o Dapper */
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM empresa WHERE id = @uID");
            var retorno = Db.Database.GetDbConnection().Query<Empresa>(query.ToString(), new {  uID = id }).FirstOrDefault();
            return retorno;
         }

        public Empresa ObterPorApelido(string apelido)
        {
            /*   através do Entity
             *   return Db.Empresa.AsNoTracking().FirstOrDefault(e => e.Apelido == apelido);
             *   */

            /* Usando o Dapper, melhor performace */
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM empresa WHERE apelido = @uAPELIDO");
            var retorno = Db.Database.GetDbConnection().Query<Empresa>(query.ToString(), new { uAPELIDO = apelido }).FirstOrDefault();
            return retorno;

        }

        public Empresa ObterPorCpfCnpj(string cpfcnpj)
        {
            //  através do Entity
            //   return Db.Empresa.AsNoTracking().FirstOrDefault(e => e.CPFCNPJ.Numero == cpfcnpj);
            /* Usando o Dapper, melhor performace */
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM empresa WHERE CpfCnpj = @uCPFCNPJ");
            var retorno = Db.Database.GetDbConnection().Query<Empresa>(query.ToString(), new { uCPFCNPJ = cpfcnpj }).FirstOrDefault();
            return retorno;

        }

        public Empresa ObterPorNome(string nome)
        {
            //   return Db.Empresa.AsNoTracking().FirstOrDefault(e => e.Nome == nome); //usando o entity
            /* Usando o Dapper, melhor performace para consulta */
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM empresa WHERE Nome = @uNOME");
            var retorno = Db.Database.GetDbConnection().Query<Empresa>(query.ToString(), new { uNOME = nome }).FirstOrDefault();
            return retorno;

        }
       
    }
}
