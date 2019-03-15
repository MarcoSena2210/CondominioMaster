using CondominioMaster.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioMaster.Application.Interfaces.AgregacaoEdificacao
{
     public interface IApplicationEdificacao : IDisposable
    {
        EdificacaoViewModel Adicionar(EdificacaoViewModel edificacao);
        EdificacaoViewModel Atualizar(EdificacaoViewModel edificacao);
        EdificacaoViewModel Remover(EdificacaoViewModel edificacao);
        IEnumerable<EdificacaoViewModel> ObterTodos();
        EdificacaoViewModel ObterPorId(int id);
        EdificacaoViewModel ObterPorCpfCnpj(string cpfcnpj);
        EdificacaoViewModel ObterPorApelido(string apelido);
        EdificacaoViewModel ObterPorNome(string nome);
    }
}
