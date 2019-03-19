using System.Collections.Generic;

namespace CondominioMaster.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit(List<string> erros); 
    }
}
