using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Interfaces.Repository;
using CondominioMaster.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// /    Vão ficar os nossas regras principais
/// </summary>
namespace CondominioMaster.Domain.Services
{
     public class ServiceEmpresa : IServiceEmpresa
     {
          #region Injeção de dependências
          private readonly IRepositoryEmpresa repoEmpresa;
          private readonly IRepositoryCondominio repoCondominio;
          #endregion Injeção de dependências

          #region Construtor 
          public ServiceEmpresa(IRepositoryEmpresa _repoEmpresa, IRepositoryCondominio _repoCondominio)
          {
               repoEmpresa = _repoEmpresa;
               repoCondominio = _repoCondominio;
          }
          #endregion Construtor 

          
          #region Adicionar Empresa
          public Empresa Adicionar(Empresa empresa)
          {
               empresa = AptoParaAdicionarEmpresa(empresa);
               if (empresa.ListaErros.Any()) return empresa;  /* retorna a lista contendo erros, pois não está vazia */

               repoEmpresa.Adicionar(empresa);
               return empresa;
          }

          private Empresa AptoParaAdicionarEmpresa(Empresa empresa)
          {
               if (!empresa.EstaConsistente()) return empresa;
               empresa = VerificarSeApelidoExisteEmInclusao(empresa);
               empresa = VerificarSeCPFCNPJExisteEmInclusao(empresa);
               return empresa;
          }

          private Empresa VerificarSeApelidoExisteEmInclusao(Empresa empresa)
          {
               if (ObterPorApelido(empresa.Apelido) != null) empresa.ListaErros.Add("O apelido " + " já existe para outra empresa");
               return empresa;
          }

          private Empresa VerificarSeCPFCNPJExisteEmInclusao(Empresa empresa)
          {
               if (ObterPorCpfCnpj(empresa.CPFCNPJ.Numero) != null) empresa.ListaErros.Add("O CPF ou CNPJ " + empresa.CPFCNPJ.Numero + " já existe em outra empresa!");
               return empresa;
          }
          #endregion Adicionar Empresa

          
          #region Atualizar Empresa
          public Empresa Atualizar(Empresa empresa)
          {
               empresa = AptoParaAlterarEmpresa(empresa);
               if (empresa.ListaErros.Any()) return empresa; /* retorna a lista contendo erros, pois não está vazia */
               repoEmpresa.Atualizar(empresa);
               return empresa;
          }
          
          private Empresa AptoParaAlterarEmpresa(Empresa empresa)
          {
               if (!empresa.EstaConsistente()) return empresa;
               empresa = VerificarSeApelidoExisteEmAlteracao(empresa);
               empresa = VerificarSeCPFCNPJExisteEmAlteracao(empresa);
               return empresa;
          }

          private Empresa VerificarSeApelidoExisteEmAlteracao(Empresa empresa)
          {
               var result = ObterPorApelido(empresa.Apelido);
               if (result != null && result.Id != empresa.Id) empresa.ListaErros.Add("O Apelido " + empresa.Apelido + " já existe em outro empresa!");
               return empresa;
          }


          private Empresa VerificarSeCPFCNPJExisteEmAlteracao(Empresa empresa)
          {
               var result = ObterPorCpfCnpj(empresa.CPFCNPJ.Numero);
               if (result != null && result.Id != empresa.Id) empresa.ListaErros.Add("O CPF ou CNPJ " + empresa.CPFCNPJ.Numero + " já existe em outro cliente!");
               return empresa;
          }
          #endregion  Atualizar Empresa


          #region Removerr Empresa
          public Empresa Remover(Empresa empresa)
          {
               empresa = VerificarSeExisteCondominioAssociadoAEmpresa(empresa);
               if (empresa.ListaErros.Any()) return empresa;

               repoEmpresa.Remover(empresa);
               return empresa;
          }

          private Empresa VerificarSeExisteCondominioAssociadoAEmpresa(Empresa empresa)
          {
               var result = repoCondominio.ObterTodos().FirstOrDefault(c => c.IdEmpresa == empresa.Id);
               if (result != null) empresa.ListaErros.Add("Existe(m) condominio associados a esta Empresa, exclusão não permtida!");
               return empresa;
          }
          #endregion Removerr Empresa


          #region Consulta Cliente
          public IEnumerable<Empresa> ObterTodos()
          {
               return repoEmpresa.ObterTodos();
          }

          public Empresa ObterPorId(int id)
          {
               return repoEmpresa.ObterPorId(id);
          }

          public Empresa ObterPorApelido(string apelido)
          {
               return repoEmpresa.ObterPorApelido(apelido);
          }

          public Empresa ObterPorCpfCnpj(string cpfcnpj)
          {
               return repoEmpresa.ObterPorCpfCnpj(cpfcnpj);
          }

          public Empresa ObterPorNome(string nome)
          {
               return repoEmpresa.ObterPorNome(nome);
          }
          #endregion

          public void Dispose()
          {
               repoEmpresa.Dispose();
               GC.SuppressFinalize(this);
          }

     }
}
