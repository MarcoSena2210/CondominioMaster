using AutoMapper;
using CondominioMaster.Application.Interfaces.AgregacaoEdificacao;
using CondominioMaster.Application.ViewModels;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Services.AgregacaoEdificacao;
using CondominioMaster.Infra.CrossCutting.Extensions;
using CondominioMaster.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Application.Services
{
    public class ApplicationEdificacao : IApplicationEdificacao
    {

        #region Injecção de dependencia e Construtor
        private readonly IServiceEdificacao serviceEdificacoes;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ApplicationEdificacao(IServiceEdificacao _serviceEdificacoes,
                                                                  IMapper _mapper, IUnitOfWork _uow)
        {
            serviceEdificacoes = _serviceEdificacoes;
            mapper = _mapper;
            uow = _uow;
        }
        #endregion Injecção de dependencia e Construtor

        #region Adicionar
            public EdificacaoViewModel Adicionar(EdificacaoViewModel edificacao)
            {
                //Orquestração para ver se vamos comitar ou não
                var edificacoesresult = mapper.Map<EdificacaoViewModel>(serviceEdificacoes.Adicionar(mapper.Map<Edificacao>(edificacao)));
                uow.Commit(edificacoesresult.ListaErros);
                return mapper.Map<EdificacaoViewModel>(edificacoesresult);
            }
        #endregion Adicionar

        #region Atualizar
        public EdificacaoViewModel Atualizar(EdificacaoViewModel edificacao)
        {
            //Orquestração para ver se vamos comitar ou não
            var edificacoesresult = mapper.Map<EdificacaoViewModel>(serviceEdificacoes.Atualizar(mapper.Map<Edificacao>(edificacao)));
            uow.Commit(edificacoesresult.ListaErros);
            return mapper.Map<EdificacaoViewModel>(edificacoesresult);
        }
        #endregion Atualizar

        #region Remover
        public EdificacaoViewModel Remover(EdificacaoViewModel edificacao)
        {
            //Orquestração para ver se vamos comitar ou não
            var edificacoesresult = mapper.Map<EdificacaoViewModel>(serviceEdificacoes.Remover(mapper.Map<Edificacao>(edificacao)));
            uow.Commit(edificacoesresult.ListaErros);
            return mapper.Map<EdificacaoViewModel>(edificacoesresult);
        }
        #endregion Remover

        #region Consultas
        public IEnumerable<EdificacaoViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<EdificacaoViewModel>>(serviceEdificacoes.ObterTodos());
        }

        public EdificacaoViewModel ObterPorId(int id)
        {
            return mapper.Map<EdificacaoViewModel>(serviceEdificacoes.ObterPorId(id));
        }

        public EdificacaoViewModel ObterPorCpfCnpj(string cpfcnpj)
        {
            return mapper.Map<EdificacaoViewModel>(serviceEdificacoes.ObterPorCpfCnpj(cpfcnpj.SomenteNumeros())  );
        }

        public EdificacaoViewModel ObterPorApelido(string apelido)
        {
            return mapper.Map<EdificacaoViewModel>(serviceEdificacoes.ObterPorApelido(apelido));
        }

        public EdificacaoViewModel ObterPorNome(string nome)
        {
        
            return mapper.Map<EdificacaoViewModel>(serviceEdificacoes.ObterPorNome(nome));
        }
        #endregion Consultas

        #region Dispose
        public void Dispose()
        {
            serviceEdificacoes.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion Dispose
    }
}
