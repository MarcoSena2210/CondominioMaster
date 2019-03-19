using AutoMapper;
using CondominioMaster.Application.Interfaces;
using CondominioMaster.Application.ViewModels.AgregacaoEdificacao;
using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Interfaces.Services;
using CondominioMaster.Infra.CrossCutting.Extensions;
using CondominioMaster.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Application.Services
{
    public class ApplicationCondominio : IApplicationCondominio
    {

        #region Injecção de dependencia e Construtor
        private readonly IServiceCondominio serviceCondominios;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ApplicationCondominio(IServiceCondominio _serviceCondominios,
                                                                  IMapper _mapper, IUnitOfWork _uow )
        {
            serviceCondominios = _serviceCondominios;
            mapper =_mapper;
            uow =_uow;
         }
        #endregion Injecção de dependencia e Construtor

        #region Adicionar 
        public CondominioViewModel Adicionar(CondominioViewModel condominio)
        {
            var condominioresult = mapper.Map<CondominioViewModel>(serviceCondominios.Adicionar(mapper.Map<Condominio>(condominio)));
            uow.Commit(condominioresult.ListaErros);
            return mapper.Map<CondominioViewModel>(condominioresult);
        }
        #endregion  Adicionar 

        #region Atualizar 
        public CondominioViewModel Atualizar(CondominioViewModel condominio)
        {
            var condominioresult = mapper.Map<CondominioViewModel>(serviceCondominios.Atualizar(mapper.Map<Condominio>(condominio)));
            uow.Commit(condominioresult.ListaErros);
            return mapper.Map<CondominioViewModel>(condominioresult);
        }
        #endregion Atualizar

        #region Remover
        public CondominioViewModel Remover(CondominioViewModel condominio)
        {
            var condominioresult = mapper.Map<CondominioViewModel>(serviceCondominios.Remover(mapper.Map<Condominio>(condominio)));
            uow.Commit(condominioresult.ListaErros);
            return mapper.Map<CondominioViewModel>(condominioresult);
        }
        #endregion Remover

        #region Consultas
        public IEnumerable<CondominioViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<CondominioViewModel>>(serviceCondominios.ObterTodos());
        }

        public CondominioViewModel ObterPorId(int id)
        {
            return mapper.Map<CondominioViewModel>(serviceCondominios.ObterPorId(id));
        }

        public CondominioViewModel ObterPorApelido(string apelido)
        {
            return mapper.Map<CondominioViewModel>(serviceCondominios.ObterPorApelido(apelido));
        }

        public CondominioViewModel ObterPorCpfCnpj(string cpfcnpj)
        {
            return mapper.Map<CondominioViewModel>(serviceCondominios.ObterPorCpfCnpj(cpfcnpj.SomenteNumeros()));
        }


        public CondominioViewModel ObterPorNome(string nome)
        {
            return mapper.Map<CondominioViewModel>(serviceCondominios.ObterPorApelido(nome));
        }
        #endregion Consultas

        #region Dispose
        public void Dispose()
        {
            serviceCondominios.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion Dispose
    }
 }
