using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Repository;
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
     /// <summary>
     /// Usando o Dapper
     /// </summary>


     public class RepositoryImovel : Repository<Imovel>, IRepositoryImovel
     {
          public RepositoryImovel(ContextEFCondominioMaster context) : base(context)
          {
          }

          public void AdicionarImovelEdificacao(Imovel imovel)
          {
               throw new NotImplementedException();
          }

          public void AtulizarImovelEdificacao(Imovel imovel)
          {
               throw new NotImplementedException();
          }

          public void RemoverImovelEdificacao(Imovel imovel)
          {
               throw new NotImplementedException();
          }


          public IEnumerable<Imovel> ObterImoveisPorEdificacaoId(int idEdificacao)
          {
               var results = from i in Db.Imovel
                             join e in Db.Edificacao on i.IdEdificacao equals e.Id
                             select new Imovel
                             {
                                  Id = i.Id,
                                  Identificador = i.Identificador,
                                  NumeroPorta = i.NumeroPorta,
                                  IdPessoaFinanceiro = i.IdPessoaFinanceiro,
                                  IdEdificacao = i.IdEdificacao,
                                  SiglaImovel = i.SiglaImovel,
                                  DataIncluiRegistro = i.DataIncluiRegistro,
                                  Edificacao = new Edificacao
                                  {
                                       Nome = e.Nome
                                  }
                             };
               return results.ToList();


               throw new NotImplementedException();
          }

          public Imovel ObterImovelPorId(int id)
          {
               StringBuilder query = new StringBuilder();
               query.Append(@" SELECT * FROM imovel WHERE id = @uID");
               var imoveis = Db.Database.GetDbConnection().Query<Imovel>(query.ToString(), new { uID = id });
               return imoveis.FirstOrDefault();
          }

          public Imovel ObterImovelPorIdentificador(string Identificador)
          {
               StringBuilder query = new StringBuilder();
               query.Append(@" SELECT * FROM imovel WHERE identificador = @uIDENTIFICADOR ");
               var imoveis = Db.Database.GetDbConnection().Query<Imovel>(query.ToString(), new { uIDENTIFICADOR = Identificador });
               return imoveis.FirstOrDefault();
          }

         
     }
}
