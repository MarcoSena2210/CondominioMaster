using CondominioMaster.Domain.Shared.Entities;
using CondominioMaster.Domain.Shared.ValueObjects;
using System;
using System.Linq;

namespace CondominioMaster.Domain.Entities
{
    public class TransacaoFinanceira : EntidadeBase
    {
        public TransacaoFinanceira()
        {
            Observacao = new ObservacaoVO(); //precisamos instanciar os VO
        }
        
        public override bool EstaConsistente()
        {
            IdPlanoContasDeveSerPreenchido();
            IdPessoaFavorecidaDeveSerPreenchido();
            IdTransacaoItemFavorecidaDeveSerPreenchido();
            return !ListaErros.Any();
        }

        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal ValorTitulo { get; set; }
        public decimal?  ValorPago { get; set; }
        public ObservacaoVO Observacao { get; set; }
        
        public int IdPlanoContas { get; set; }
        public virtual PlanoContas PlanoConta { get; set; }

        public int IdPessoaFavorecida { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public int IdTransacaoItem { get; set; }
        public virtual TransacaoItem TransacaoItem { get; set; }


        private void IdPlanoContasDeveSerPreenchido()
        {
            if (IdPlanoContas == 0) ListaErros.Add("O campo código do plano de contas  dever informado!");
        }

        private void IdPessoaFavorecidaDeveSerPreenchido()
        {
            if (IdPessoaFavorecida == 0) ListaErros.Add("O campo código dd pessoa favorecida  dever informado!");
        }

        private void IdTransacaoItemFavorecidaDeveSerPreenchido()
        {
            if (IdTransacaoItem == 0) ListaErros.Add("O campo código do Item da transação deve ser informado!");
        }

    }
}
