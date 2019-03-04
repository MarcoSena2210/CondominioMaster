using CondominioMaster.Domain.Shared.Entities;
using CondominioMaster.Domain.Shared.ValueObjects;
using System.Linq;

namespace CondominioMaster.Domain.Entities
{
    public class PlanoContas : EntidadeBase
    {
        public PlanoContas()
        {
            Descricao = new DescricaoVO();
        }

        public override bool EstaConsistente()
        {
            ChavePranoContaPaiDeveSerPreenchido();
            OTipoLancamentoDeveSerPreenchidoComTouL();
            return !ListaErros.Any();
        }

        public string ChaveContaPai { get; set; } //1
        public string ChaveContaFilha { get; set; } //1.1.11.
        public DescricaoVO Descricao { get; set; }
        public string TituloLancamento { get; set; }  //T ou R


        protected void ChavePranoContaPaiDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(ChaveContaPai)) ListaErros.Add("O número do plano de contas deve ser preenchido!");
        }

        protected void ChavePranoContaFilhaDeveSerPreenchido()
        {
            if (string.Equals(TituloLancamento, "L")  &&    string.IsNullOrEmpty(ChaveContaFilha)) ListaErros.Add("O número do plano de conta filha deve ser preenchido!");
        }


        protected void OTipoLancamentoDeveSerPreenchidoComTouL() {
            if (string.IsNullOrEmpty(TituloLancamento)) ListaErros.Add("O tipo de lançamento deve ser preenchido") ;
            if (!string.Equals(TituloLancamento,"T") && !string.Equals(TituloLancamento, "L")) ListaErros.Add("O tipo de lançamento deve ser preenchido com T ou L");  
        }


    }


}
