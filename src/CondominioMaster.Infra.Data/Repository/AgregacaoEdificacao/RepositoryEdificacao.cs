using CondominioMaster.Domain.DTO;
using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao;
using CondominioMaster.Infra.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CondominioMaster.Infra.Data.Repository.AgregacaoEdificacao
{
     /// <summary>
     ///      Usando o ADO, pois o dapper não dá suporte facil para trabbalhar com Values Objects 
     /// </summary>

     public class RepositoryEdificacao : Repository<Edificacao>, Domain.Interfaces.Repository.AgregacaoEdificacao.RepositoryEdificacao
     {
          public RepositoryEdificacao(ContextEFCondominioMaster context)
              : base(context)
          {
          }
      

          //public IEnumerable<EdificacaoDTO> ObterListagemEdificacao()
          //{
          //     throw new NotImplementedException();
          //}

          //public EdificacaoDTO ObterPorIdCompleto(int id)
          //{
          //     throw new NotImplementedException();
          //}


          //public IEnumerable<Imovel> ObterImovelEspecifico(int idImovel)
          //{
          //     throw new NotImplementedException();
          //}

          //public Imovel ObterImovelEdificacaoPorId(int id)
          //{
          //     //    return Db.Imovel.AsNoTracking().FirstOrDefault(i => i.Id == id);
          //     StringBuilder query = new StringBuilder();
          //     query.AppendLine(@"SELECT * FROM imovel I
          //                            INNER JOIN edificacao   E   ON i.IdEdificacao = e.Id
          //                            INNER JOIN condominio C   ON e.IdCondominio = c.Id
          //                            INNER JOIN empresa     EM ON e.IdEmpresa = em.Id 
          //                            INNER JOIN imovel         I     ON e.Id                     = i.IdEdificacao
          //                            WHERE  I.Id = @uID");
          //     var imoveisDaEdificacao = Db.Database.GetDbConnection().Query<Imovel, Edificacao, Condominio, Empresa, Imovel>(query.ToString(),
          //        (I, E, C, EM) =>
          //        {
          //             I.Edificacao = E;
          //             E.Condominio = C;
          //             C.Empresa = EM;
          //             return I;
          //        }, new { @uID = id });
          //     return imoveisDaEdificacao.FirstOrDefault();

          //}

          //public void AdicionarImovelEdificacao(Imovel imovel)
          //{
          //     Db.Imovel.Add(imovel);
          //}

          //public void AtulizarImovelEdificacao(Imovel imovel)
          //{
          //     Db.Imovel.Update(imovel);
          //}

          //public void RemoverImovelEdificacao(Imovel imovel)
          //{
          //     Db.Imovel.Remove(imovel);
          //}

          //public IEnumerable<Imovel> ObterImovelEdificacao(int idEdificacao)
          //{
          //     StringBuilder query = new StringBuilder();
          //     query.AppendLine(@"SELECT * FROM imovel I
          //                            INNER JOIN edificacao   E   ON i.IdEdificacao = e.Id
          //                            INNER JOIN condominio C   ON e.IdCondominio = c.Id
          //                            INNER JOIN empresa     EM ON e.IdEmpresa = em.Id 
          //                            INNER JOIN imovel         I     ON e.Id                     = i.IdEdificacao
          //                            WHERE  Ed.Id = @uIDEDIFICACAO");
          //     var imoveisDaEdificacao = Db.Database.GetDbConnection().Query<Imovel, Edificacao, Condominio, Empresa, Imovel>(query.ToString(),
          //        (I, E, C, EM) =>
          //        {
          //             I.Edificacao = E;
          //             E.Condominio = C;
          //             C.Empresa = EM;
          //             return I;
          //        }, new { @uuIDEDIFICACAO = idEdificacao });
          //     return imoveisDaEdificacao;

          //}
          //public IEnumerable<Imovel> ObterTodosImoveis()
          //{
          //     /* Usando o Dapper */
          //     //    StringBuilder query = new StringBuilder();
          //     //    query.Append(@"SELECT * FROM imovel 
          //     //                             ORDER BY id DESC");
          //     //    return Db.Database.GetDbConnection().Query<Imovel>(query.ToString());

          //     var results = from i in Db.Imovel
          //                   join e in Db.Edificacao on i.IdEdificacao equals e.Id

          //                   select new Imovel
          //                   {
          //                        Id = i.Id,

          //                        Identificador = i.Identificador,
          //                        NumeroPorta = i.NumeroPorta,
          //                        IdEdificacao = i.IdEdificacao,
          //                        Edificacao = new Edificacao { Nome = e.Nome },
          //                   };
          //     return results.ToList();

          //}

          //public IEnumerable<Imovel> ObterImoveisDaEdificacao(int idEdificacao)
          //{
          //     return Db.Imovel.Where(i => i.IdEdificacao == idEdificacao).OrderBy(i => i.Edificacao.Nome);
          //}




  


          public override IEnumerable<Edificacao> ObterTodos()
          {
               StringBuilder query = new StringBuilder();
               query.Append(@"SELECT * FROM edificacao ORDER BY Nome");
               return ExecutarDataReader(null, query.ToString());
          }


          public Edificacao ObterEdificacaoPorID(int id)
          {
               SqlParameter[] param = { new SqlParameter("@uID", id) };  // Cria a variavel que vais receber o parâmetro
               StringBuilder query = new StringBuilder();
               query.Append(@"SELECT * FROM edificacao WHERE id = @uID");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }


          public Edificacao ObterPorApelido(string apelido)
          {
               SqlParameter[] param = { new SqlParameter("@uAPELIDO", apelido) };  // Cria a variavel que vais receber o parâmetro
               StringBuilder query = new StringBuilder();
               query.Append(@"SELECT * FROM edificacao WHERE apelido = @uAPELIDO");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }


          public Edificacao ObterPorNome(string nome)
          {
               SqlParameter[] param = { new SqlParameter(" @uNome ", nome) };  // Cria a variavel que vais receber o parâmetro         
               StringBuilder query = new StringBuilder();
               query.Append(@"SELECT * FROM empresa WHERE Nome = @uNOME");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();

          }


          public Edificacao ObterPorCpfCnpj(string cpfcnpj)
          {
                SqlParameter[] param = { new SqlParameter(" @uCPFCNPJ  ", cpfcnpj) };  // Cria a variavel que vais receber o parâmetro
               StringBuilder query = new StringBuilder();
               query.Append(@"SELECT * FROM edificacao WHERE CpfCnpj = @uCPFCNPJ");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }
                        


          public Edificacao AtribuirEmpresas(Edificacao edificacao, SqlDataReader reader)
          {
               edificacao.Id = reader.GetInt32(0);
               edificacao.Apelido = reader.SafeGetString(1);
               edificacao.Nome = reader.SafeGetString(2);
               edificacao.CPFCNPJ.Numero = reader.SafeGetString(3);
               edificacao.Email.Endereco = reader.SafeGetString(4);
               edificacao.Endereco.Logradouro = reader.SafeGetString(5);
               edificacao.Endereco.Bairro = reader.SafeGetString(6);
               edificacao.Endereco.Cidade = reader.SafeGetString(7);
               edificacao.Endereco.UF.UF = reader.SafeGetString(8);
               edificacao.Endereco.CEP.Codigo = reader.SafeGetString(9);
               return edificacao;
          }


          private IEnumerable<Edificacao> ExecutarDataReader(SqlParameter[] param, string sql)
          {
               /// <summary>
               ///   ExecutarDataReader, recebe um array de SQL parametro e uma string sql
               /// </summary>
               /// <param name="param"></param>
               /// <param name="sql"></param>
               ///       string cn = retorna a string de conexão que foi estabelecida 
               ///       é iniciacializada uma lista de edificacao, que foi dada o nome de "edificacoes"
               /// <returns></returns>

               string cn = ObterStringConexao();
               List<Edificacao> edificacoes = new List<Edificacao>();
               using (SqlConnection con = new SqlConnection(cn))
               {
                    con.Open();                                                             //abre conexao 
                    SqlCommand cmd = new SqlCommand(sql, con); //Execulta o Ado
                    cmd.Parameters.Clear();
                    if (param != null)                                                     //Se existir param, no array e o ado 
                    {
                         cmd.Parameters.AddRange(param);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                         while (reader.Read())
                         {
                              Edificacao edificacao = new Edificacao(); //Cria uma novo objeto empresa e adiciona na lista de empresas
                              edificacao = AtribuirEmpresas(edificacao, reader);
                              edificacoes.Add(edificacao);
                         }
                    }
                    return edificacoes;                                                //retorna a lista(IEnumerable) de empresas 
               }
          }

     }
}
