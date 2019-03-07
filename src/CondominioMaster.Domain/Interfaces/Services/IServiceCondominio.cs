using CondominioMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioMaster.Domain.Interfaces.Services
{
    public  interface IServiceCondominio : IDisposable
    {
        Condominio Adicionar(Condominio condominio);
        Condominio Atualizar(Condominio condominio);
        Condominio Remover(Condominio condominio);
        IEnumerable<Condominio> ObterTodos();
        Condominio ObterPorId(int id);
        Condominio ObterPorCpfCnpj(string cpfcnpj);
        Condominio ObterPorApelido(string apelido);
        Condominio ObterPorNome(string nome);
    }
}
