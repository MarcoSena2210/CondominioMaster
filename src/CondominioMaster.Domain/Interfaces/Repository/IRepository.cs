using CondominioMaster.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CondominioMaster.Domain.Interfaces.Repository
{
    public  interface IRepository<TEntidade> : IDisposable where TEntidade : EntidadeBase
    {
        void Adicionar(TEntidade obj);
        void Atualizar(TEntidade obj);
        void Remover(TEntidade obj);
        TEntidade ObterPorId(int id);
        IEnumerable<TEntidade> ObterTodos();

        IEnumerable<TEntidade> Buscar(Expression<Func<TEntidade, bool>> predicate );
        bool EstaAtivo(int id);
    }
}
