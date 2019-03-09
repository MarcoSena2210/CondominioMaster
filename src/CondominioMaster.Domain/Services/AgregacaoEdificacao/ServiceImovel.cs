using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Services.AgregacaoEdificacao;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Services.AgregacaoEdificacao
{
    public class ServiceImovel : IServiceImovel
    {
        private readonly IRepositoryImovel repoImovel;
       

        public ServiceImovel(IRepositoryImovel _repoImovel)
        {
            repoImovel = _repoImovel;
        }

        #region Adicionar-Atualizar-Remover

        public Imovel Adicionar(Imovel imovel)
        {
            repoImovel.Adicionar(imovel);
            return imovel;
        }

        public Imovel Atualizar(Imovel imovel)
        {
            repoImovel.Atualizar(imovel);
            return imovel;
        }

        public Imovel Remover(Imovel imovel)
        {
            repoImovel.Remover(imovel);
            return imovel;
        }

        #endregion


        public IEnumerable<Imovel> ObterImoveisPorEdificacao(int idEdificacao)
        {
            return repoImovel.ObterImoveisPorEdificacao(idEdificacao);
        }

        public Imovel ObterImovelPorId(int id)
        {
            return repoImovel.ObterImovelPorId(id);
        }

        public Imovel ObterImovelPorIdentificador(string Identificador)
        {
            return repoImovel.ObterImovelPorIdentificador(Identificador);
        }

        public void Dispose()
        {
            repoImovel.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
