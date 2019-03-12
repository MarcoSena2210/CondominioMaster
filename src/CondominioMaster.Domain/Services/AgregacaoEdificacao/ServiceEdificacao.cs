using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Services.AgregacaoEdificacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioMaster.Domain.Services.AgregacaoEdificacao
{
     public class ServiceEdificacao : IServiceEdificacao
     {

          #region Injeção de dependências
          private readonly RepositoryEdificacao repoEdificacao;
          private readonly IRepositoryImovel repoImovel;
          #endregion Injeção de dependências


          #region Construtor 
          public ServiceEdificacao(RepositoryEdificacao _repoEdificacao, IRepositoryImovel _repoImovel)
          {
               repoEdificacao = _repoEdificacao;
               repoImovel = _repoImovel;
          }
          #endregion Construtor 


          #region Adicionar Edificacao
          public Edificacao Adicionar(Edificacao edificacao)
          {
               edificacao = AptoParaAdicionarEdificacao(edificacao);
               if (edificacao.ListaErros.Any()) return edificacao;  /* retorna a lista contendo erros, pois não está vazia */

               repoEdificacao.Adicionar(edificacao);
               return edificacao;
          }

          private Edificacao AptoParaAdicionarEdificacao(Edificacao edificacao)
          {
               if (!edificacao.EstaConsistente()) return edificacao;
               edificacao = VerificarSeApelidoExisteEmInclusao(edificacao);
               edificacao = VerificarSeCPFCNPJExisteEmInclusao(edificacao);
               return edificacao;
          }

          private Edificacao VerificarSeApelidoExisteEmInclusao(Edificacao edificacao)
          {
               if (ObterPorApelido(edificacao.Apelido) != null) edificacao.ListaErros.Add("O apelido " + " já existe para outra edificacao");
               return edificacao;
          }

          private Edificacao VerificarSeCPFCNPJExisteEmInclusao(Edificacao edificacao)
          {
               if (ObterPorCpfCnpj(edificacao.CPFCNPJ.Numero) != null) edificacao.ListaErros.Add("O CPF ou CNPJ " + edificacao.CPFCNPJ.Numero + " já existe em outra edificacao !");
               return edificacao;
          }
          #endregion Adicionar Edificacao


          #region Atualizar Edificacao
          public Edificacao Atualizar(Edificacao edificacao)
          {
               edificacao = AptoParaAlterarEdificacao(edificacao);
               if (edificacao.ListaErros.Any()) return edificacao; /* retorna a lista contendo erros, pois não está vazia */
               repoEdificacao.Atualizar(edificacao);
               return edificacao;
          }

          private Edificacao AptoParaAlterarEdificacao(Edificacao edificacao)
          {
               if (!edificacao.EstaConsistente()) return edificacao;
               edificacao = VerificarSeApelidoExisteEmAlteracao(edificacao);
               edificacao = VerificarSeCPFCNPJExisteEmAlteracao(edificacao);
               return edificacao;
          }

          private Edificacao VerificarSeApelidoExisteEmAlteracao(Edificacao edificacao)
          {
               var result = ObterPorApelido(edificacao.Apelido);
               if (result != null && result.Id != edificacao.Id) edificacao.ListaErros.Add("O Apelido " + edificacao.Apelido + " já existe em outra edificacao!");
               return edificacao;
          }

          private Edificacao VerificarSeCPFCNPJExisteEmAlteracao(Edificacao edificacao)
          {
               var result = ObterPorCpfCnpj(edificacao.CPFCNPJ.Numero);
               if (result != null && result.Id != edificacao.Id) edificacao.ListaErros.Add("O CPF ou CNPJ " + edificacao.CPFCNPJ.Numero + " já existe em outra edificacao!");
               return edificacao; throw new NotImplementedException();
          }
          #endregion Atualizar Edificacao


          #region Remover Edificacao
          public Edificacao Remover(Edificacao edificacao)
          {
               edificacao = VerificarSeExisteImovelAssociadoAoCondominio(edificacao);
               if (edificacao.ListaErros.Any()) return edificacao;

               repoEdificacao.Remover(edificacao);
               return edificacao;
          }

          private Edificacao VerificarSeExisteImovelAssociadoAoCondominio(Edificacao edificacao)
          {
               var result = repoImovel.ObterTodos().FirstOrDefault(i => i.IdEdificacao == edificacao.Id);
               if (result != null) edificacao.ListaErros.Add("Existe(m) imovel  associados a esta Edificação, exclusão não permtida!");
               return edificacao;
          }
          #endregion Remover Edificacao


          #region Consulta Edificacao
          public IEnumerable<Edificacao> ObterTodos()
          {
               return repoEdificacao.ObterTodos();
          }

          public Edificacao ObterPorApelido(string apelido)
          {
               return repoEdificacao.ObterPorApelido(apelido);
          }

          public Edificacao ObterPorCpfCnpj(string cpfcnpj)
          {
               return repoEdificacao.ObterPorCpfCnpj(cpfcnpj);
          }

          public Edificacao ObterPorId(int id)
          {
               return repoEdificacao.ObterPorId(id);
          }

          public Edificacao ObterPorNome(string nome)
          {
               return repoEdificacao.ObterPorNome(nome);
          }
          #endregion Consulta Edificacao


          #region Dispose
          public void Dispose()
          {
               repoEdificacao.Dispose();
               GC.SuppressFinalize(this);
          }
          #endregion Dispose
     }
}
