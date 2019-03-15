using CondominioMaster.Application.ViewModels;
using CondominioMaster.Application.ViewModels.AgregacaoEdificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioMaster.Application.Interfaces.AgregacaoEdificacao
{
     public interface IApplicationImovel : IDisposable
    {
        ImovelViewModel Adicionar(ImovelViewModel imovel);
          ImovelViewModel Atualizar(ImovelViewModel imovel);
          ImovelViewModel Remover(ImovelViewModel imovel);
          IEnumerable<ImovelViewModel> ObterTodos();
          ImovelViewModel ObterPorId(int id);
          ImovelViewModel ObterPorCpfCnpj(string cpfcnpj);
          ImovelViewModel ObterPorApelido(string apelido);
          ImovelViewModel ObterPorNome(string nome);


    }
}
