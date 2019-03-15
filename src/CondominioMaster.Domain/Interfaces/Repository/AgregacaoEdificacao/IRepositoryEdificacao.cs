using CondominioMaster.Domain.DTO;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao
{
    public interface IRepositoryEdificacao : IRepository<Edificacao>
    {
      
        Edificacao ObterPorCpfCnpj(string cpfcnpj);
        Edificacao ObterPorApelido(string apelido);
        Edificacao ObterPorNome(string nome);
        //             movel ObterEdificacaoPorId(int id);
        //IEnumerable<Imovel> ObterImovelEdificacao(int idEdificacao);
      
        //EdificacaoDTO ObterPorIdCompleto(int id);
        //IEnumerable<EdificacaoDTO> ObterListagemEdificacao();
    }
}
