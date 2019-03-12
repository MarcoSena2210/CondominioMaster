using CondominioMaster.Domain.DTO;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao
{
    public interface RepositoryEdificacao : IRepository<Edificacao>
    {
        void AdicionarImovelEdificacao(Imovel imovel);
        void AtulizarImovelEdificacao(Imovel imovel);
        void RemoverImovelEdificacao(Imovel imovel);

        Edificacao ObterPorCpfCnpj(string cpfcnpj);
        Edificacao ObterPorApelido(string apelido);
        Edificacao ObterPorNome(string nome);



        Imovel ObterImovelEdificacaoPorId(int id);
        IEnumerable<Imovel> ObterImovelEdificacao(int idEdificacao);
      
        EdificacaoDTO ObterPorIdCompleto(int id);
        IEnumerable<EdificacaoDTO> ObterListagemEdificacao();
    }
}
