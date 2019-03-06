using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CondominioMaster.Domain.Entities
{
    public class Condominio : PessoaBase
    {
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        public ICollection<Edificacao> Edificacao { get; set; }
        public override bool EstaConsistente()
        {
           
            CPFouCNPJDeveSerPreenchido();
            CPFouCNPJDeveSerValido();
            EmaiDeveSerValido();
            EmailDeveTerUmTamanhoLimite(100);
            EnderecoDeveSerPreenchido();
            EnderecoDeveTerUmTamanhoLimite(100);
            BairroDeveTerUmTamanhoLimite(30);
            CidadeDeveSerPreenchida();
            CidadeDeveTerUmTamanhoLimite(30);
            UFDeveSerPreenchida();
            UFDeveSerValida();
            CepDeveSerValido();
            return !ListaErros.Any();
        }
    }
}
