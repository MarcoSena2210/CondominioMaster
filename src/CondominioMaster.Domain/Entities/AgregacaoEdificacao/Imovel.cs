using CondominioMaster.Domain.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioMaster.Domain.Entities.AgregacaoEdificacao
{
    public class Imovel : EntidadeBase
    {
               
        public string NumeroPorta { get; set; } //4a ou 401
        public string Identificador { get; set; } // id.condomio + Id.Edificacao + Sigla + Numero do Apartamento 

        public int IdEdificacao { get; set; }
        public virtual Edificacao Edificacoes { get; set; }


        public override bool EstaConsistente()
        {
            NumeroPortaDeveSerPreenchido();
            IdEdificacaoDeveSerPreenchido();
            IdentificadorPortaDeveSerPreenchido();

            return !ListaErros.Any();
        }


        public void NumeroPortaDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(NumeroPorta)) ListaErros.Add("O campo número da porta do imóvel deve ser preenchido!");

        }

        private void IdentificadorPortaDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Identificador)) ListaErros.Add("O campo identificador da porta do imóvel deve ser preenchido!");
        }

        private void IdEdificacaoDeveSerPreenchido()
        {
            if (IdEdificacao == 0) ListaErros.Add("O campo código da edificação  dever informado!");
        }



    }
}
