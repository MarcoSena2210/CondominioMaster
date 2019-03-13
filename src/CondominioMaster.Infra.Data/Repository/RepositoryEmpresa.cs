using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Interfaces.Repository;
using CondominioMaster.Infra.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System;


namespace CondominioMaster.Infra.Data.Repository
{
/// <summary>
///      Usando o ADO, pois o dapper não dá suporte facil para trabbalhar com Values Objects 
/// </summary>
     public class RepositoryEmpresa : Repository<Empresa>, IRepositoryEmpresa
     {
          public RepositoryEmpresa(ContextEFCondominioMaster context)
              : base(context)
          {

          }


          public override IEnumerable<Empresa> ObterTodos()
          {
               StringBuilder query = new StringBuilder();
               query.Append(@"SELECT * FROM empresa ORDER BY id DESC");
               return ExecutarDataReader(null, query.ToString());
          }


          public override Empresa ObterPorId(int id)
          {
               SqlParameter[] param = { new SqlParameter("@uID", id) };  // Cria a variavel que vais receber o parâmetro
               StringBuilder query = new StringBuilder();
               query.Append(@"SELECT * FROM empresa WHERE id = @uID");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }


          public Empresa ObterPorApelido(string apelido)
          {
               SqlParameter[] param = { new SqlParameter("@uAPELIDO", apelido) };  // Cria a variavel que vais receber o parâmetro
               StringBuilder query = new StringBuilder();
               query.Append(@"SELECT * FROM empresa WHERE apelido = @uAPELIDO");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }


          public Empresa ObterPorCpfCnpj(string cpfcnpj)
          {
               SqlParameter[] param = { new SqlParameter(" @uCPFCNPJ  ", cpfcnpj) };  // Cria a variavel que vais receber o parâmetro
               StringBuilder query = new StringBuilder();
               query.Append(@"SELECT * FROM empresa WHERE CpfCnpj = @uCPFCNPJ");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }


          public Empresa ObterPorNome(string nome)
          {
               SqlParameter[] param = { new SqlParameter(" @uNome ", nome) };  // Cria a variavel que vais receber o parâmetro                            StringBuilder query = new StringBuilder();
               StringBuilder query = new StringBuilder();
               query.Append(@"SELECT * FROM empresa WHERE Nome = @uNOME");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }


          public Empresa AtribuirEmpresas(Empresa empresa, SqlDataReader reader)
          {
               empresa.Id = reader.GetInt32(0);
               empresa.Apelido = reader.SafeGetString(1);
               empresa.Nome = reader.SafeGetString(2);
               empresa.CPFCNPJ.Numero = reader.SafeGetString(3);
               empresa.Email.Endereco = reader.SafeGetString(4);
               empresa.Endereco.Logradouro = reader.SafeGetString(5);
               empresa.Endereco.Bairro = reader.SafeGetString(6);
               empresa.Endereco.Cidade = reader.SafeGetString(7);
               empresa.Endereco.UF.UF = reader.SafeGetString(8);
               empresa.Endereco.CEP.Codigo = reader.SafeGetString(9);
               return empresa;
          }


          private IEnumerable<Empresa> ExecutarDataReader(SqlParameter[] param, string sql)
          {
               /// <summary>
               ///   ExecutarDataReader, recebe um array de SQL parametro e uma string sql
               /// </summary>
               /// <param name="param"></param>
               /// <param name="sql"></param>
               ///       string cn = retorna a string de conexão que foi estabelecida 
               ///       é iniciacializada uma lista de empresa, que foi dada o nome de "empresas"
               /// <returns></returns>

               string cn = ObterStringConexao();
               List<Empresa> empresas = new List<Empresa>();
               using (SqlConnection con = new SqlConnection(cn))
               {
                    con.Open();  //abre conexao 
                    SqlCommand cmd = new SqlCommand(sql, con); //Execulta o Ado
                    cmd.Parameters.Clear();
                    if (param != null)      //Se existir param, no array e o ado 
                    {
                         cmd.Parameters.AddRange(param);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                         while (reader.Read())
                         {
                              Empresa empresa = new Empresa(); //Cria uma novo objeto empresa e adiciona na lista de empresas
                              empresa = AtribuirEmpresas(empresa, reader);
                              empresas.Add(empresa);
                         }
                    }
                    return empresas; //retorna a lista(IEnumerable) de empresas 
               }
          }

     }
}
