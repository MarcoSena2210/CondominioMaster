using CondominioMaster.Domain.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CondominioMaster.Domain.Entities.AgregacaoEdificacao
{
    public class Edificacao : PessoaBase
    {

        public int IdCondominio { get; set; }
        public virtual Condominio Condominio { get; set; }

        public ICollection<Imovel> Imovel { get; set; }

        public override bool EstaConsistente()
        {
            IdCondominioDeveSerPreenchido();

           
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
        

        private void IdCondominioDeveSerPreenchido()
        {
            if (IdCondominio == 0) ListaErros.Add("O campo código do condominio deve ser informado!");
        }
    }
}
