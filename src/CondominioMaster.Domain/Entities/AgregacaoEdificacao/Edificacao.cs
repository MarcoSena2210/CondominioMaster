using CondominioMaster.Domain.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioMaster.Domain.Entities.AgregacaoEdificacao
{
    public class Edificacao : PessoaBase
    {
        


        public ICollection<Imovel> Imoveis { get; set; }
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
