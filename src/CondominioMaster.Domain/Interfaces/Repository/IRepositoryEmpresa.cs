using CondominioMaster.Domain.Entities;

namespace CondominioMaster.Domain.Interfaces.Repository
{
    public  interface IRepositoryEmpresa : IRepository<Empresa>
    {
        Empresa ObterPorCpfCnpj(string cpfcnpj);
        Empresa ObterPorApelido(string apelido);
        Empresa ObterPorNome(string nome);
    }
}
