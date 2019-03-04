using CondominioMaster.Domain.Entities.AgregacaoEdificacao;

namespace CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao
{
    public interface IRepositoryImovel : IRepository<Imovel>
    {
        Imovel ObterPorIdentificacao(string Identificacao);
     
    }
}
