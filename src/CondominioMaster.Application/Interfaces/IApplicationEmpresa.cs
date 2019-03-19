using CondominioMaster.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Application.Interfaces
{
    public interface IApplicationEmpresa : IDisposable
    {
        EmpresaViewModel Adicionar(EmpresaViewModel empresa);
        EmpresaViewModel Atualizar(EmpresaViewModel empresa);
        EmpresaViewModel Remover(EmpresaViewModel empresa);
        IEnumerable<EmpresaViewModel> ObterTodos();
        EmpresaViewModel ObterPorId(int id);
        EmpresaViewModel ObterPorCpfCnpj(string cpfcnpj);
        EmpresaViewModel ObterPorApelido(string apelido);
        EmpresaViewModel ObterPorNome(string nome);
    }
}
