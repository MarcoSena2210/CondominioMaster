using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao
{
    public interface IRepositoryImovel : IRepository<Imovel>
    {
     
        IEnumerable<Imovel> ObterImoveisPorEdificacaoId(int idEdificacao);
        Imovel ObterImovelPorId(int id);
        Imovel ObterImovelPorIdentificador(string Identificador);

    }
}
