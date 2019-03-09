using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Services.AgregacaoEdificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioMaster.Domain.Services.AgregacaoEdificacao
{
    public class ServiceEdificacao : IServiceEdificacao
    {
        private readonly IRepositoryEdificacao repoEdificacao;

        public ServiceEdificacao(IRepositoryEdificacao _repoEdificacao)
        {
            repoEdificacao = _repoEdificacao;
        }

        #region Adicionar-Atualizar-Remover

        public Edificacao Adicionar(Edificacao edificacao)
        {
            repoEdificacao.Adicionar(edificacao);
            return edificacao;
        }

        public Edificacao Atualizar(Edificacao edificacao)
        {
            repoEdificacao.Atualizar(edificacao);
            return edificacao;
        }
        
        public Edificacao Remover(Edificacao edificacao)
        {
            repoEdificacao.Remover(edificacao);
            return edificacao;
        }
        #endregion  

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

        public void Dispose()
        {
            repoEdificacao.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
