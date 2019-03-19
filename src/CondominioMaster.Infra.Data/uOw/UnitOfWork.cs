using CondominioMaster.Infra.Data.Context;
using CondominioMaster.Infra.Data.Interfaces;
using System.Collections.Generic;

namespace CondominioMaster.Infra.Data.uOw
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextEFCondominioMaster context;

        public UnitOfWork(ContextEFCondominioMaster _context)
        {
            context = _context;
        }

        public void Commit(List<string> erros)
        {
            context.SaveChanges();
        }
    }
}
