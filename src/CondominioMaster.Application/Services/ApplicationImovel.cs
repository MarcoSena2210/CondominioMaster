using AutoMapper;
using CondominioMaster.Application.Interfaces.AgregacaoEdificacao;
using CondominioMaster.Application.ViewModels.AgregacaoEdificacao;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Services.AgregacaoEdificacao;
using CondominioMaster.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioMaster.Application.Services
{
    public class ApplicationImovel : IApplicationImovel
    {

        #region Injecção de dependencia e Construtor
        private readonly IServiceImovel serviceImoveis;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ApplicationImovel(IServiceImovel _serviceImovei, IMapper _mapper, IUnitOfWork _uow)
        {
            serviceImoveis = _serviceImovei;
            mapper = _mapper;
            uow = _uow;
        }

        #endregion Injecção de dependencia e Construtor

        #region Adicionar
        public ImovelViewModel Adicionar(ImovelViewModel imovel)
        {
            var imovelresult = mapper.Map<ImovelViewModel>(serviceImoveis.Adicionar(mapper.Map<Imovel>(imovel)));
            uow.Commit(imovelresult.ListaErros);
            return mapper.Map<ImovelViewModel>(imovelresult);
        }
        #endregion Adicionar

        #region Atualizar
        public ImovelViewModel Atualizar(ImovelViewModel imovel)
        {
            var imovelresult = mapper.Map<ImovelViewModel>(serviceImoveis.Atualizar(mapper.Map<Imovel>(imovel)));
            uow.Commit(imovelresult.ListaErros);
            return mapper.Map<ImovelViewModel>(imovelresult);
        }
        #endregion Atualizar

        #region Remover
        public ImovelViewModel Remover(ImovelViewModel imovel)
        {
            var imovelresult = mapper.Map<ImovelViewModel>(serviceImoveis.Remover(mapper.Map<Imovel>(imovel)));
            uow.Commit(imovelresult.ListaErros);
            return mapper.Map<ImovelViewModel>(imovelresult);
        }
        #endregion Remover

        public ImovelViewModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public ImovelViewModel ObterPorIdentificador(string apelido)
        {
            throw new NotImplementedException();
        }

        public ImovelViewModel ObterPorNomeDoResponsavel(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImovelViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
