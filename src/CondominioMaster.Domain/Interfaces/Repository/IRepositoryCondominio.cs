using CondominioMaster.Domain.Entities;

namespace CondominioMaster.Domain.Interfaces.Repository
{
    public interface IRepositoryCondominio : IRepository<Condominio>
    {
        Condominio ObterPorCpfCnpj(string cpfcnpj);
        Condominio ObterPorApelido(string apelido);
        Condominio ObterPorNome(string Nome);
    }
}