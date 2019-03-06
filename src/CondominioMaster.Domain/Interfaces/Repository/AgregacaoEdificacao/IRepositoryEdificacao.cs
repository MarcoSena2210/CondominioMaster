using CondominioMaster.Domain.DTO;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao
{
    public interface IRepositoryEdificacao : IRepository<Edificacao>
    {
        void AdicionarImovelEdificacao(Imovel imovel);
        void AtulizarImovelEdificacao(Imovel imovel);
        void RemoverImovelEdificacao(Imovel imovel);

        Imovel ObterImovelEdificacaoPorId(int id);
        IEnumerable<Imovel> ObterImovelEdificacao(int idEdificacao);
      
        EdificacaoDTO ObterPorIdCompleto(int id);
        IEnumerable<EdificacaoDTO> ObterListagemEdificacao();
    }
}
