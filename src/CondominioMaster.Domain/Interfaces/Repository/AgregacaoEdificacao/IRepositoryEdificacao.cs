using CondominioMaster.Domain.Entities.AgregacaoEdificacao;

namespace CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao
{
    public interface IRepositoryEdificacao : IRepository<Edificacao>
    {
        Edificacao ObterPorCpfCnpj(string cpfcnpj);
        Edificacao ObterPorApelido(string apelido);
        Edificacao ObterPorNome(string Nome);
    }
}