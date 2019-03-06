using CondominioMaster.Domain.Interfaces.Repository;
using CondominioMaster.Domain.Shared.Entities;
using CondominioMaster.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace CondominioMaster.Infra.Data.Repository
{
    public class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : EntidadeBase
    {
        protected ContextEFCondominioMaster Db;    //injeta a dependência
        protected DbSet<TEntidade> DbSet;                 //injeta a dependência

        public Repository(ContextEFCondominioMaster context)
        {
            Db = context;
            DbSet = Db.Set<TEntidade>();
        }

        public virtual void Adicionar(TEntidade obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntidade obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remover(TEntidade obj)
        {
            DbSet.Remove(obj);
        }

        public virtual IEnumerable<TEntidade> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual TEntidade ObterPorId(int id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        protected string ObterStringConexao()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").
                Build();
            return config.GetConnectionString("DefaultConnection");
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<TEntidade> Buscar(Expression<Func<TEntidade, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public bool EstaAtivo(int id)
        {
            throw new NotImplementedException();
        }
    }
}