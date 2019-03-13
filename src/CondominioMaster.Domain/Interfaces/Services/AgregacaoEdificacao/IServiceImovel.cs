using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Interfaces.Services.AgregacaoEdificacao
{
    public interface IServiceImovel : IDisposable
    {
        Imovel Adicionar(Imovel imovel);
        Imovel Atualizar(Imovel imovel);
        Imovel Remover(Imovel imovel);
        IEnumerable<Imovel> ObterImoveisPorEdificacaoId(int idEdificacao);
        Imovel ObterImovelPorId(int id);
        Imovel ObterImovelPorIdentificador(string Identificador);
     
    }
}
