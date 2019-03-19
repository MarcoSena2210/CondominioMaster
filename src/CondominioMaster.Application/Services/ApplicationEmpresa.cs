using AutoMapper;
using CondominioMaster.Application.Interfaces;
using CondominioMaster.Application.ViewModels;
using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Interfaces.Services;
using DrVendas.dddcore.Application.AppVendas.Interfaces;
using DrVendas.dddcore.Application.AppVendas.ViewModels;
using DrVendas.dddcore.Domain.Entidades;
using DrVendas.dddcore.Domain.Interfaces.Services;
using DrVendas.dddcore.Infra.CrossCutting.Extensions;
using DrVendas.dddcore.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Application
{
     namespace CondominioMaster.Application.Services
{ 
    public class ApplicationEmpresa : IApplicationEmpresa
    { 
          private readonly IServiceEmpresa serviceEmpresas;
           private readonly IMapper mapper;
               //    private readonly IUnitOfWork uow;

        public ApplicationEmpresa(IServiceEmpresa _serviceEmpresas,
                                   IMapper _mapper, IUnitOfWork _uow)
        {
               serviceEmpresas = _serviceEmpresas;
            mapper = _mapper;
            uow = _uow;
        }
        #region Adicionar 
        public EmpresaViewModel Adicionar(EmpresaViewModel empresa)
        {
            //Orquestração para ver se vamos comitar ou não
            var empresaresult = mapper.Map<EmpresaViewModel>(serviceEmpresas.Adicionar(mapper.Map<Empresa>(empresa)));
            uow.Commit(empresaresult.ListaErros);
            return mapper.Map<EmpresaViewModel>(empresaresult);
        }
        #endregion

        #region Atualizar 
        public EmpresaViewModel Atualizar(EmpresaViewModel cliente)
        {
            //Orquestração para ver se vamos comitar ou não
            var empresaresult = mapper.Map<EmpresaViewModel>(serviceEmpresas.Atualizar(mapper.Map<Cliente>(cliente)));
            uow.Commit(empresaresult.ListaErros);
            return mapper.Map<EmpresaViewModel>(empresaresult);
         }
        #endregion

        #region Remover
        public ClienteViewModel Remover(ClienteViewModel cliente)
        {
            //Orquestração para ver se vamos comitar ou não
            var clienteresult = mapper.Map<ClienteViewModel>(serviceEmpresas.Remover(mapper.Map<Cliente>(cliente)));
            uow.Commit(clienteresult.ListaErros);
            return mapper.Map<ClienteViewModel>(clienteresult);
        }
        #endregion

        #region Consultas

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<ClienteViewModel>>(serviceclientes.ObterTodos());
        }

        public ClienteViewModel ObterPorId(int id)
        {
            return mapper.Map<ClienteViewModel>(serviceclientes.ObterPorId(id));
        }

        public ClienteViewModel ObterPorApelido(string apelido)
        {
            return mapper.Map<ClienteViewModel>(serviceclientes.ObterPorApelido(apelido));
        }

        public ClienteViewModel ObterPorCpfCnpj(string cpfcnpj)
        {
            return mapper.Map<ClienteViewModel>(serviceclientes.ObterPorCpfCnpj(cpfcnpj.SomenteNumeros()));
        }
        #endregion

        public void Dispose()
        {
            serviceclientes.Dispose();
            GC.SuppressFinalize(this);
        }

               public EdificacaoViewModel Adicionar(EdificacaoViewModel empresa)
               {
                    throw new NotImplementedException();
               }

               public EdificacaoViewModel Atualizar(EdificacaoViewModel empresa)
               {
                    throw new NotImplementedException();
               }

               public EdificacaoViewModel Remover(EdificacaoViewModel empresa)
               {
                    throw new NotImplementedException();
               }

               IEnumerable<EdificacaoViewModel> IApplicationEmpresa.ObterTodos()
               {
                    throw new NotImplementedException();
               }

               EdificacaoViewModel IApplicationEmpresa.ObterPorId(int id)
               {
                    throw new NotImplementedException();
               }

               EdificacaoViewModel IApplicationEmpresa.ObterPorCpfCnpj(string cpfcnpj)
               {
                    throw new NotImplementedException();
               }

               EdificacaoViewModel IApplicationEmpresa.ObterPorApelido(string apelido)
               {
                    throw new NotImplementedException();
               }

               public EdificacaoViewModel ObterPorNome(string nome)
               {
                    throw new NotImplementedException();
               }
          }
}
