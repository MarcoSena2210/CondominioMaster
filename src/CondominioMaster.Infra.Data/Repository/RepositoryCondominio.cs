using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Interfaces.Repository;
using CondominioMaster.Infra.Data.Context;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
/// <summary>
///      Usando o ADO, pois o dapper não dá suporte facil para trabbalhar com Values Objects 
/// </summary>
namespace CondominioMaster.Infra.Data.Repository
{

     public class RepositoryCondominio : Repository<Condominio>, IRepositoryCondominio
     {

          public RepositoryCondominio(ContextEFCondominioMaster context)
              : base(context)
          {

          }


          public override IEnumerable<Condominio> ObterTodos()
          {
               StringBuilder query = new StringBuilder();
               query.Append(@" SELECT * FROM condominio c  INNER JOIN empresa e ON c.IdEmpresa = e.Id
                            ORDER BY P.ID DESC   ");
               return ExecutarDataReader(null, query.ToString());
          }


          public override Condominio ObterPorId(int id)
          {
               SqlParameter[] param = { new SqlParameter("@uID", id) };  // Cria a variavel que vais receber o parâmetro
               StringBuilder query = new StringBuilder();
               query.Append(@" SELECT * FROM condominio c 
                                    INNER JOIN empresa e ON c.IdEmpresa = e.Id
                                    WHERE c.Id = @uId  ");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }


          public Condominio ObterPorApelido(string apelido)
          {
               SqlParameter[] param = { new SqlParameter("@uAPELIDO", apelido) };  // Cria a variavel que vais receber o parâmetro
               StringBuilder query = new StringBuilder();
               query.Append(@" SELECT * FROM condominio c 
                                    INNER JOIN empresa e ON c.IdEmpresa = e.Id
                                    WHERE c.apelido  = @uAPELIDO    ");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }
          

          public Condominio ObterPorCpfCnpj(string cpfcnpj)
          {
               SqlParameter[] param = { new SqlParameter(" @uCPFCNPJ  ", cpfcnpj) };  // Cria a variavel que vais receber o parâmetro
               StringBuilder query = new StringBuilder();
               query.Append(@" SELECT * FROM condominio c 
                                    INNER JOIN empresa e ON c.IdEmpresa = e.Id
                                    WHERE c.CpfCnpj  = @uCPFCNPJ            ");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }


          public Condominio ObterPorNome(string nome)
          {
               SqlParameter[] param = { new SqlParameter(" @uNome ", nome) };  // Cria a variavel que vais receber o parâmetro             
               StringBuilder query = new StringBuilder();
               query.Append(@" SELECT * FROM condominio c 
                                    INNER JOIN empresa e ON c.IdEmpresa = e.Id
                                    WHERE c.Nome = @uNome  ");
               return ExecutarDataReader(param, query.ToString()).FirstOrDefault();
          }


          public Condominio AtribuirEmpresas(Condominio condominio, SqlDataReader reader)
          {
               condominio.Id = reader.GetInt32(0);
               condominio.Apelido = reader.SafeGetString(1);
               condominio.Nome = reader.SafeGetString(2);
               condominio.CPFCNPJ.Numero = reader.SafeGetString(3);
               condominio.Email.Endereco = reader.SafeGetString(4);
               condominio.Endereco.Logradouro = reader.SafeGetString(5);
               condominio.Endereco.Bairro = reader.SafeGetString(6);
               condominio.Endereco.Cidade = reader.SafeGetString(7);
               condominio.Endereco.UF.UF = reader.SafeGetString(8);
               condominio.Endereco.CEP.Codigo = reader.SafeGetString(9);
               return condominio;
          }


          private IEnumerable<Condominio> ExecutarDataReader(SqlParameter[] param, string sql)
          {
               /// <summary>
               ///   ExecutarDataReader, recebe um array de SQL parametro e uma string sql
               /// </summary>
               /// <param name="param"></param>
               /// <param name="sql"></param>
               ///       string cn = retorna a string de conexão que foi estabelecida 
               ///       é iniciacializada uma lista de condominio, que foi dada o nome de "condominios"
               /// <returns></returns>

               string cn = ObterStringConexao();
               List<Condominio> condominios = new List<Condominio>();
               using (SqlConnection con = new SqlConnection(cn))
               {
                    con.Open();                                                             //abre conexao 
                    SqlCommand cmd = new SqlCommand(sql, con); //Execulta o Ado
                    cmd.Parameters.Clear();
                    if (param != null)                                                      //Se existir param, no array e o ado 
                    {
                         cmd.Parameters.AddRange(param);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                         while (reader.Read())
                         {
                              Condominio condominio = new Condominio(); //Cria uma novo objeto condominio e adiciona na lista de condominios
                              condominio = AtribuirEmpresas(condominio, reader);
                              condominios.Add(condominio);
                         }
                    }
                    return condominios;                                                     //retorna a lista(IEnumerable) de condominios 
               }
          }
     }
}
