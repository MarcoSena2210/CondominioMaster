using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Services.AgregacaoEdificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioMaster.Domain.Services.AgregacaoEdificacao
{
     public class ServiceImovel : IServiceImovel
     {
          private const string ponto = ".";
          #region Injeção de dependências
          private readonly IRepositoryImovel repoImovel;
          private readonly IRepositoryEdificacao repoEdificacao;
          #endregion Injeção de dependências


          #region Construtor 
          public ServiceImovel(IRepositoryImovel _repoImovel, IRepositoryEdificacao _repoEdificacao)
          {
               repoImovel = _repoImovel;
               repoEdificacao = _repoEdificacao;
          }
          #endregion Construtor 


          #region Adicionar Imovel
          public Imovel Adicionar(Imovel imovel)
          {
               MontaIdentificadorDoImovel(imovel);
                imovel = AptoParaAdicionarImovel(imovel);
               if (imovel.ListaErros.Any()) return imovel;  /* retorna a lista contendo erros, pois não está vazia */
               repoImovel.Adicionar(imovel);
               return imovel;
          }

          private Imovel AptoParaAdicionarImovel(Imovel imovel)
          {
               if (!imovel.EstaConsistente()) return imovel;
               imovel = VerificarSeIdentificadorExisteEmInclusao(imovel);
               imovel = VerificaSeIdEdificacaoEstaPreenchido(imovel);
               imovel = VerificaSeSiglaImovelEstaPreenchido(imovel);
               imovel = VerificaSeNumeroDaPortaEstaPreenchido(imovel);
               return imovel;
          }
          #endregion Adicionar Imovel


          #region Atualizar Imovel
          public Imovel Atualizar(Imovel imovel)
          {
               repoImovel.Atualizar(imovel);
               return imovel;
          }

          private Imovel AptoParaAlterarImovel(Imovel imovel)
          {
               imovel = AptoParaAlterarImovel(imovel);
               if (!imovel.EstaConsistente()) return imovel;
               imovel = VerificarSeIdentificadorExisteEmInclusao(imovel);
               imovel = VerificaSeIdEdificacaoEstaPreenchido(imovel);
               imovel = VerificaSeSiglaImovelEstaPreenchido(imovel);
               imovel = VerificaSeNumeroDaPortaEstaPreenchido(imovel);
               return imovel;
          }
          #endregion Atualizar Imovel


          #region Remover Imovel
          public Imovel Remover(Imovel imovel)
          {
               
               imovel = VerifcaSeExisteImovelAssociadoAUmaEdificacao(imovel);
               if (imovel.ListaErros.Any()) return imovel;

               repoImovel.Remover(imovel);
               return imovel;
          }

          private Imovel VerifcaSeExisteImovelAssociadoAUmaEdificacao(Imovel imovel)
          {
              var result = repoImovel.ObterTodos().FirstOrDefault(i => i.IdEdificacao  == imovel.IdEdificacao);
               if (result != null) imovel.ListaErros.Add("Existe(m) edificação  associados a este imóvel, exclusão não permtida!");
               return imovel;
          }
          #endregion  Remover Imovel


          #region Validadões
          private Imovel VerificarSeIdentificadorExisteEmInclusao(Imovel imovel)
          {
               var result = repoImovel.ObterTodos().FirstOrDefault(i => i.Identificador  == imovel.Identificador);
               return null;
          }
  
          private Imovel VerificaSeIdEdificacaoEstaPreenchido(Imovel imovel)
          {
               if ((imovel.IdEdificacao <= 0)) imovel.ListaErros.Add("O id de Edificação deve ser informado!");
               return imovel;  
          }

          private Imovel VerificaSeSiglaImovelEstaPreenchido(Imovel imovel)
          {    if (string.IsNullOrEmpty(imovel.SiglaImovel)) imovel.ListaErros.Add("A sigla deve ser informada!");
               return imovel;
          }

          private Imovel VerificaSeNumeroDaPortaEstaPreenchido(Imovel imovel)
          {
               if (string.IsNullOrEmpty(imovel.NumeroPorta)) imovel.ListaErros.Add("O número da porta deve ser informado!");
               return imovel;
          }

          public string MontaIdentificadorDoImovel(Imovel imovel)
          {
                  Edificacao objEdificacao = new Edificacao();
                  objEdificacao =  repoEdificacao.ObterPorId(imovel.IdEdificacao);

                    //   int IdCondominio = 15;
                    StringBuilder resultado = new StringBuilder();
               // id.condomio + Id.Edificacao + Sigla + Numero do Apartamento 
        
               resultado =resultado.Append(objEdificacao.IdCondominio + ponto +   imovel.IdEdificacao  
                                                                                                        + ponto + "AP" + ponto + imovel.NumeroPorta );
               return resultado.ToString();

          }
          #endregion Validadões


          #region Consultas
          public IEnumerable<Imovel> ObterImoveisPorEdificacaoId(int idEdificacao)
          {
               return repoImovel.ObterImoveisPorEdificacaoId(idEdificacao);
          }

          public Imovel ObterImovelPorId(int id)
          {
               return repoImovel.ObterImovelPorId(id);
          }

          public Imovel ObterImovelPorIdentificador(string Identificador)
          {
               return repoImovel.ObterImovelPorIdentificador(Identificador);
          }
          #endregion Consultas


          #region Dispose
          public void Dispose()
          {
               repoImovel.Dispose();
               GC.SuppressFinalize(this);
          }
          #endregion Dispose
     }
}
