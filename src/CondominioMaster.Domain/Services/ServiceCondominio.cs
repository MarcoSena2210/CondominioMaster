using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Interfaces.Repository;
using CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioMaster.Domain.Services
{
     public class ServiceCondominio : IServiceCondominio
     {

          #region Injeção de dependências
          private readonly IRepositoryCondominio repoCondominio;
          private readonly RepositoryEdificacao repoEdificacao;
          #endregion Injeção de dependências


          #region Construtor 
          public ServiceCondominio(IRepositoryCondominio _repoCondominio, RepositoryEdificacao _repoEdificacao)
          {
               repoCondominio = _repoCondominio;
               repoEdificacao = _repoEdificacao;
          }
          #endregion Construtor 

          #region Adicionar Condominio
          public Condominio Adicionar(Condominio condominio)
          {
               condominio = AptoParaAdicionarCondominio(condominio);
               if (condominio.ListaErros.Any()) return condominio;  /* retorna a lista contendo erros, pois não está vazia */
               repoCondominio.Adicionar(condominio);
               return condominio;
          }

          private Condominio AptoParaAdicionarCondominio(Condominio condominio)
          {
               if (!condominio.EstaConsistente()) return condominio;
               condominio = VerificarSeApelidoExisteEmInclusao(condominio);
               condominio = VerificarSeCPFCNPJExisteEmInclusao(condominio);
               return condominio;
          }

          private Condominio VerificarSeCPFCNPJExisteEmInclusao(Condominio condominio)
          {
               if (ObterPorApelido(condominio.Apelido) != null) condominio.ListaErros.Add("O apelido " + " já existe para outro condominio");
               return condominio;
          }

          private Condominio VerificarSeApelidoExisteEmInclusao(Condominio condominio)
          {
               if (ObterPorCpfCnpj(condominio.CPFCNPJ.Numero) != null) condominio.ListaErros.Add("O CPF ou CNPJ " + condominio.CPFCNPJ.Numero + " já existe em outra empresa!");
               return condominio;
          }
          #endregion Adicionar Condominio


          #region Atualizar Condominio
          public Condominio Atualizar(Condominio condominio)
          {
               condominio = AptoParaAlterarCondominio(condominio);
               if (condominio.ListaErros.Any()) return condominio; /* retorna a lista contendo erros, pois não está vazia */
               repoCondominio.Atualizar(condominio);
               return condominio;
          }

          private Condominio AptoParaAlterarCondominio(Condominio condominio)
          {
               if (!condominio.EstaConsistente()) return condominio;
               condominio = VerificarSeApelidoExisteEmAlteracao(condominio);
               condominio = VerificarSeCPFCNPJExisteEmAlteracao(condominio);
               return condominio;
          }

          private Condominio VerificarSeApelidoExisteEmAlteracao(Condominio condominio)
          {
               var result = ObterPorApelido(condominio.Apelido);
               if (result != null && result.Id != condominio.Id) condominio.ListaErros.Add("O Apelido " + condominio.Apelido + " já existe em outro condominio!");
               return condominio;
          }

          private Condominio VerificarSeCPFCNPJExisteEmAlteracao(Condominio condominio)
          {
               var result = ObterPorCpfCnpj(condominio.CPFCNPJ.Numero);
               if (result != null && result.Id != condominio.Id) condominio.ListaErros.Add("O CPF ou CNPJ " + condominio.CPFCNPJ.Numero + " já existe em outro condominio com esse CPF ou CNPJ!");
               return condominio;
          }
          #endregion Atualizar Condominio


          #region Remover Condominio
          public Condominio Remover(Condominio condominio)
          {
               condominio = VerificarSeExisteEdificacaoAssociadoAoCondominio(condominio);
               if (condominio.ListaErros.Any()) return condominio;

               repoCondominio.Remover(condominio);
               return condominio;
          }

          private Condominio VerificarSeExisteEdificacaoAssociadoAoCondominio(Condominio condominio)
          {
               var result = repoEdificacao.ObterTodos().FirstOrDefault(e => e.IdCondominio == condominio.Id);
               if (result != null) condominio.ListaErros.Add("Existe(m) condominio associados a esta Empresa, exclusão não permtida!");
               return condominio;
          }
          #endregion Remover Condominio


          #region Consulta Condominio
          public IEnumerable<Condominio> ObterTodos()
          {
               return repoCondominio.ObterTodos();
          }

          public Condominio ObterPorId(int id)
          {
               return repoCondominio.ObterPorId(id);
          }

          public Condominio ObterPorApelido(string apelido)
          {
               return repoCondominio.ObterPorApelido(apelido);
          }

          public Condominio ObterPorCpfCnpj(string cpfcnpj)
          {
               return repoCondominio.ObterPorCpfCnpj(cpfcnpj);
          }

          public Condominio ObterPorNome(string nome)
          {
               return repoCondominio.ObterPorNome(nome);
          }
          #endregion Consulta Condominio


          #region Dispose
          public void Dispose()
          {
               repoCondominio.Dispose();
               GC.SuppressFinalize(this);
          }
          #endregion Dispose
     }
}
