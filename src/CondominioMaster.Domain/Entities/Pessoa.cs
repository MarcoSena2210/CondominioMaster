using CondominioMaster.Domain.Shared.Entidades;
using System.Linq;

namespace CondominioMaster.Domain.Entities
{
    public class Pessoa : PessoaBase
    {

       
        public override bool EstaConsistente()
        {
            PrimeiroNomeDeveSerPreenchido();
            PrimeiroNomeDeveTerUmTamanhoLimite(50);
            UltimoNomeDeveSerPreenchido();
            UltimoNomeDeveTerUmTamanhoLimite(50);
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
