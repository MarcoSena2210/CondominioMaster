using CondominioMaster.Domain.DTO;
using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao;
using CondominioMaster.Infra.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioMaster.Infra.Data.Repository.AgregacaoEdificacao
{

    public class RepositoryEdificacao : Repository<Edificacao>, IRepositoryEdificacao
    {
        public RepositoryEdificacao(ContextEFCondominioMaster context)
            : base(context)
        {
         }
        /* So foi possivel sobrescrever pq foi declarado  como virtual na classe pai(Repository)
        *, neste caso vamos usar o Dapper para as consultas com stringbuilder.
        * Melhora a performace consideravelmente.
        */
     
    
        public IEnumerable<Imovel> ObterImovelEspecifico(int idImovel)
        {
            throw new NotImplementedException();
        }
   
        public IEnumerable<EdificacaoDTO> ObterListagemEdificacao()
        {
            throw new NotImplementedException();
        }

        public EdificacaoDTO ObterPorIdCompleto(int id)
        {
            throw new NotImplementedException();
        }
        
        public  Imovel ObterImovelEdificacaoPorId(int id)
        {
            //    return Db.Imovel.AsNoTracking().FirstOrDefault(i => i.Id == id);
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM imovel I
                                      INNER JOIN edificacao   E   ON i.IdEdificacao = e.Id
                                      INNER JOIN condominio C   ON e.IdCondominio = c.Id
                                      INNER JOIN empresa     EM ON e.IdEmpresa = em.Id 
                                      INNER JOIN imovel         I     ON e.Id                     = i.IdEdificacao
                                      WHERE  I.Id = @uID");
            var imoveisDaEdificacao = Db.Database.GetDbConnection().Query<Imovel, Edificacao, Condominio, Empresa, Imovel>(query.ToString(),
               (I, E, C, EM) =>
               {
                   I.Edificacao = E;
                   E.Condominio = C;
                   C.Empresa = EM;
                   return I;
               }, new { @uID = id });
            return imoveisDaEdificacao.FirstOrDefault();

        }

        public void AdicionarImovelEdificacao(Imovel imovel)
        {
            Db.Imovel.Add(imovel);
        }

        public void AtulizarImovelEdificacao(Imovel imovel)
        {
            Db.Imovel.Update(imovel);
        }

        public void RemoverImovelEdificacao(Imovel imovel)
        {
            Db.Imovel.Remove(imovel);
        }

        public IEnumerable<Imovel> ObterTodosImoveis()
        {
            /* Usando o Dapper */
            //    StringBuilder query = new StringBuilder();
            //    query.Append(@"SELECT * FROM imovel 
            //                             ORDER BY id DESC");
            //    return Db.Database.GetDbConnection().Query<Imovel>(query.ToString());

            var results = from i in Db.Imovel
                          join e in Db.Edificacao on i.IdEdificacao equals e.Id

                          select new Imovel
                          {
                              Id = i.Id,

                              Identificador = i.Identificador,
                              NumeroPorta = i.NumeroPorta,
                              IdEdificacao = i.IdEdificacao,
                              Edificacao = new Edificacao { Nome = e.Nome },
                          };
            return results.ToList();

        }

        public IEnumerable<Imovel> ObterImoveisDaEdificacao(int idEdificacao)
        {
            return Db.Imovel.Where(i => i.IdEdificacao == idEdificacao).OrderBy(i => i.Edificacao.Nome);
        }

        public Edificacao ObterPorApelido(string apelido)
        {
            /*   através do Entity
             *   return Db.Empresa.AsNoTracking().FirstOrDefault(e => e.Apelido == apelido);
             *   */

            /* Usando o Dapper, melhor performace */
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM edificacao WHERE apelido = @uAPELIDO");
            var retorno = Db.Database.GetDbConnection().Query<Edificacao>(query.ToString(), new { uAPELIDO = apelido }).FirstOrDefault();
            return retorno;

        }

        public Edificacao ObterPorCpfCnpj(string cpfcnpj)
        {
            //  através do Entity
            //   return Db.Empresa.AsNoTracking().FirstOrDefault(e => e.CPFCNPJ.Numero == cpfcnpj);
            /* Usando o Dapper, melhor performace */
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM edificacao WHERE CpfCnpj = @uCPFCNPJ");
            var retorno = Db.Database.GetDbConnection().Query<Edificacao>(query.ToString(), new { uCPFCNPJ = cpfcnpj }).FirstOrDefault();
            return retorno;

        }

        public Edificacao ObterPorNome(string nome)
        {
            //   return Db.Empresa.AsNoTracking().FirstOrDefault(e => e.Nome == nome); //usando o entity
            /* Usando o Dapper, melhor performace para consulta */
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM empresa WHERE Nome = @uNOME");
            var retorno = Db.Database.GetDbConnection().Query<Edificacao>(query.ToString(), new { uNOME = nome }).FirstOrDefault();
            return retorno;

        }




        //public Imovel ObterImovelDaEdificacaoPorId(int id)
        //{
        //    //    return Db.Imovel.AsNoTracking().FirstOrDefault(i => i.Id == id);
        //    StringBuilder query = new StringBuilder();
        //    query.AppendLine(@"SELECT * FROM imovel I
        //                              INNER JOIN edificacao   E   ON i.IdEdificacao = e.Id
        //                              INNER JOIN condominio C   ON e.IdCondominio = c.Id
        //                              INNER JOIN empresa     EM ON e.IdEmpresa = em.Id 
        //                              INNER JOIN imovel         I     ON e.Id                     = i.IdEdificacao
        //                              WHERE  I.Id = @uID");
        //    var imoveisDaEdificacao = Db.Database.GetDbConnection().Query<Imovel, Edificacao, Condominio, Empresa, Imovel>(query.ToString(),
        //       (I, E, C, EM) =>
        //       {
        //           I.Edificacao = E;
        //           E.Condominio = C;
        //           C.Empresa = EM;
        //           return I;
        //       }, new { @uID = id });
        //    return imoveisDaEdificacao.FirstOrDefault();
        //}
        public IEnumerable<Imovel> ObterImovelEdificacao(int idEdificacao)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM imovel I
                                      INNER JOIN edificacao   E   ON i.IdEdificacao = e.Id
                                      INNER JOIN condominio C   ON e.IdCondominio = c.Id
                                      INNER JOIN empresa     EM ON e.IdEmpresa = em.Id 
                                      INNER JOIN imovel         I     ON e.Id                     = i.IdEdificacao
                                      WHERE  Ed.Id = @uIDEDIFICACAO");
            var imoveisDaEdificacao = Db.Database.GetDbConnection().Query<Imovel, Edificacao, Condominio, Empresa, Imovel>(query.ToString(),
               (I, E, C, EM) =>
               {
                   I.Edificacao = E;
                   E.Condominio = C;
                   C.Empresa = EM;
                   return I;
               }, new { @uuIDEDIFICACAO = idEdificacao });
            return imoveisDaEdificacao;

        }

   
    }
}
