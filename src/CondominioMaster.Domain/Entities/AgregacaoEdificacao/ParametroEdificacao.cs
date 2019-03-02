using CondominioMaster.Domain.Shared.Entidades;
using CondominioMaster.Domain.Shared.Enums;
using System.Linq;

namespace CondominioMaster.Domain.Entities.AgregacaoEdificacao
{
    public class ParametroEdificacao : EntidadeBase
    {
        public ParametroEdificacao(int idCondominio, int idEdificacao, byte numeroImoveisPorEdificacao,
                                                  byte diaVencimentoBoleto,byte diaParaDesconto,ETipoCondominio tipoCondominio,
                                                  ETipoJuro tipoJuro,ETipoMulta tipoMulta, ETipoCobranca tipoCobranca,
                                                  ETipoFundoReserva  tipoFundoReserva,  ETipoDesconto tipoDesconto, 
                                                  decimal percentuaJuro, decimal percentuaMulta, decimal percentuaFundoReserva,
                                                   decimal percentuaDesconto, decimal valorCondominio, decimal valorDesconto,
                                                   decimal valorMulta, decimal valorFundoReserva)
        {   IdCondominio = idCondominio;
            IdEdificacao = idEdificacao;
            NumeroImoveisPorEdificacao = numeroImoveisPorEdificacao;
            DiaVencimentoBoleto = diaVencimentoBoleto;
            DiaParaDesconto = diaParaDesconto;
            TipoCondominio = tipoCondominio;
            TipoJuro = tipoJuro;
            TipoMulta = tipoMulta;
            TipoCobranca = tipoCobranca;
            TipoFundoReserva = tipoFundoReserva;
            TipoDesconto = tipoDesconto;
            PercentuaJuro = percentuaJuro;
            PercentuaMulta = percentuaMulta;
            PercentuaFundoReserva = percentuaFundoReserva;
            PercentuaDesconto = percentuaDesconto;

            ValorCondominio = valorCondominio;
            ValorDesconto = valorDesconto;
            ValorMulta = valorMulta;
            ValorFundoReserva = valorFundoReserva;
        }

        public int IdCondominio { get; private set; }
        public int IdEdificacao { get; private set; }
        public byte NumeroImoveisPorEdificacao { get; private set; }
        public byte DiaVencimentoBoleto { get; private set; }
        public byte DiaParaDesconto { get; private set; }

        public ETipoCondominio TipoCondominio { get; private set; }
        public ETipoJuro TipoJuro { get; private set; }
        public ETipoMulta TipoMulta { get; private set; }
        public ETipoCobranca TipoCobranca { get; private set; }
        public ETipoFundoReserva TipoFundoReserva { get; private set; }
        public ETipoDesconto TipoDesconto { get; private set; }

        public decimal PercentuaJuro { get; private set; }
        public decimal PercentuaMulta { get; private set; }
        public decimal PercentuaFundoReserva { get; private set; }
        public decimal PercentuaDesconto { get; private set; }

        public decimal ValorCondominio { get; private set; }
        public decimal ValorDesconto { get; private set; }
        public decimal ValorMulta { get; private set; }
        public decimal ValorFundoReserva { get; private set; }

        public override bool EstaConsistente()
        {
            IdCondominioDeveSerPreenchido();
            IdEdificacaoDeveSerPreenchido();
            NumeroDeImoveisPorEdificacaoDeveSerSuperiorAZero();
            ValorCondominioDeveSerSuperiorAZero();
            return !ListaErros.Any();
        }

        #region Validações 
        private void IdCondominioDeveSerPreenchido()
        {
            if (IdCondominio == 0) ListaErros.Add("O campo código do condominio deve ser informado!");
        }

        private void IdEdificacaoDeveSerPreenchido()
        {
            if (IdEdificacao == 0) ListaErros.Add("O campo código da edificação  dever informado!");
        }
            
        private void NumeroDeImoveisPorEdificacaoDeveSerSuperiorAZero()
        {
            if (NumeroImoveisPorEdificacao <= 0) ListaErros.Add("O campo número de Imoveis deve ser maior que zero!");
        }


        //public ETipoCobranca TipoCobranca { get; private set; }
        //public ETipoFundoReserva TipoFundoReserva { get; private set; }
        //public ETipoDesconto TipoDesconto { get; private set; }

        //public decimal PercentuaJuro { get; private set; }
        //public decimal PercentuaMulta { get; private set; }
        //public decimal PercentuaFundoReserva { get; private set; }
        //public decimal PercentuaDesconto { get; private set; }

        public void ValorCondominioDeveSerSuperiorAZero() {
            if (ValorCondominio <= 0) ListaErros.Add("O campovalor do condominio deve ser maior que zero!");
         }

        //public decimal ValorDesconto { get; private set; }
        //public decimal ValorMulta { get; private set; }
        //public decimal ValorFundoReserva { get; private set; }
                     
        #endregion Validações
    }
}
