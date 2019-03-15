using CondominioMaster.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Application.Interfaces
{
    public interface IApplicationEmpresa : IDisposable
    {
        EdificacaoViewModel Adicionar(EdificacaoViewModel empresa);
        EdificacaoViewModel Atualizar(EdificacaoViewModel empresa);
        EdificacaoViewModel Remover(EdificacaoViewModel empresa);
        IEnumerable<EdificacaoViewModel> ObterTodos();
        EdificacaoViewModel ObterPorId(int id);
        EdificacaoViewModel ObterPorCpfCnpj(string cpfcnpj);
        EdificacaoViewModel ObterPorApelido(string apelido);
        EdificacaoViewModel ObterPorNome(string nome);
    }
}
