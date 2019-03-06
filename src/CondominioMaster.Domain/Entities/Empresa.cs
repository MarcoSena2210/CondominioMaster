using CondominioMaster.Domain.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CondominioMaster.Domain.Entities
{
    public class Empresa : PessoaBase
    {
        public ICollection<Condominio> Condominio { get; set; }

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
