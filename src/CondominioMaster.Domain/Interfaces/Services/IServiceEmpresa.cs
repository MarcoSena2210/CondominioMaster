using CondominioMaster.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Interfaces.Services
{
    public interface IServiceEmpresa  : IDisposable
    {
        Empresa Adicionar(Empresa empresa);
        Empresa Atualizar(Empresa empresa);
        Empresa Remover(Empresa empresa);
        IEnumerable<Empresa> ObterTodos();
        Empresa ObterPorId(int id);
        Empresa ObterPorCpfCnpj(string cpfcnpj);
        Empresa ObterPorApelido(string apelido);
        Empresa ObterPorNome(string nome);
    }
}
