using CondominioMaster.Application.ViewModels.AgregacaoEdificacao;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Application.Interfaces.AgregacaoEdificacao
{
    public interface IApplicationImovel : IDisposable
    {
          ImovelViewModel Adicionar(ImovelViewModel imovel);
          ImovelViewModel Atualizar(ImovelViewModel imovel);
          ImovelViewModel Remover(ImovelViewModel imovel);
          IEnumerable<ImovelViewModel> ObterTodos();
          ImovelViewModel ObterPorId(int id);
          ImovelViewModel ObterPorIdentificador(string apelido);
          ImovelViewModel ObterPorNomeDoResponsavel(string nome);


    }
}
