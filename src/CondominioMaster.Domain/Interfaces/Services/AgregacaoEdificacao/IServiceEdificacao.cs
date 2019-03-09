using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Interfaces.Services.AgregacaoEdificacao
{
    public interface IServiceEdificacao : IDisposable
    {
        Edificacao Adicionar(Edificacao edificacao);
        Edificacao Atualizar(Edificacao edificacao);
        Edificacao Remover(Edificacao edificacao);
        IEnumerable<Edificacao> ObterTodos();
        Edificacao ObterPorId(int id);
        Edificacao ObterPorCpfCnpj(string cpfcnpj);
        Edificacao ObterPorApelido(string apelido);
        Edificacao ObterPorNome(string nome);
    }
}
