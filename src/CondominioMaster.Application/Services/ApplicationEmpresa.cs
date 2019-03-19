using AutoMapper;
using CondominioMaster.Application.Interfaces;
using CondominioMaster.Application.ViewModels;
using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Interfaces.Services;
using CondominioMaster.Infra.CrossCutting.Extensions;
using CondominioMaster.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Application
{
    namespace CondominioMaster.Application.Services
    {
        public class ApplicationEmpresa : IApplicationEmpresa
        {

            #region Injecção de dependencia e Construtor
            private readonly IServiceEmpresa serviceEmpresas;
            private readonly IMapper mapper;
            private readonly IUnitOfWork uow;

            public ApplicationEmpresa(IServiceEmpresa _serviceEmpresas,
                                       IMapper _mapper, IUnitOfWork _uow)
            {
                serviceEmpresas = _serviceEmpresas;
                mapper = _mapper;
                uow = _uow;
            }
            #endregion Injecção de dependencia e Construtor

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
            public EmpresaViewModel Atualizar(EmpresaViewModel empresa)
            {
                //Orquestração para ver se vamos comitar ou não
                var empresaresult = mapper.Map<EmpresaViewModel>(serviceEmpresas.Atualizar(mapper.Map<Empresa>(empresa)));
                uow.Commit(empresaresult.ListaErros);
                return mapper.Map<EmpresaViewModel>(empresaresult);
            }
            #endregion

            #region Remover
            public EmpresaViewModel Remover(EmpresaViewModel empresa)
            {
                //Orquestração para ver se vamos comitar ou não
                var empresaresult = mapper.Map<EmpresaViewModel>(serviceEmpresas.Remover(mapper.Map<Empresa>(empresa)));
                uow.Commit(empresaresult.ListaErros);
                return mapper.Map<EmpresaViewModel>(empresaresult);
            }
            #endregion

            #region Consultas

            public IEnumerable<EmpresaViewModel> ObterTodos()
            {
                return mapper.Map<IEnumerable<EmpresaViewModel>>(serviceEmpresas.ObterTodos());
            }

            public EmpresaViewModel ObterPorId(int id)
            {
                return mapper.Map<EmpresaViewModel>(serviceEmpresas.ObterPorId(id));
            }

            public EmpresaViewModel ObterPorApelido(string apelido)
            {
                return mapper.Map<EmpresaViewModel>(serviceEmpresas.ObterPorApelido(apelido));
            }

            public EmpresaViewModel ObterPorCpfCnpj(string cpfcnpj)
            {
                return mapper.Map<EmpresaViewModel>(serviceEmpresas.ObterPorCpfCnpj(cpfcnpj.SomenteNumeros()));
            }

            public EmpresaViewModel ObterPorNome(string nome)
            {
                return mapper.Map<EmpresaViewModel>(serviceEmpresas.ObterPorNome(nome));
            }
            #endregion Consultas

            #region Dispose
            public void Dispose()
            {
                serviceEmpresas.Dispose();
                GC.SuppressFinalize(this);
            }
            #endregion Dispose


        }
    }
}
