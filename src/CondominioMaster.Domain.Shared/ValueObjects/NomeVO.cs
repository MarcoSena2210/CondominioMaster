using System.Collections.Generic;

namespace CondominioMaster.Domain.Shared.ValueObjects
{

    public class NomeVO 
    {
        public  NomeVO()
        {

        }
        public NomeVO(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            PrimeiroNomeDeveSerPreenchido();
            PrimeiroNomeDeveTerUmTamanhoLimite(50);
            UltimoNomeDeveSerPreenchido();
            UltimoNomeDeveTerUmTamanhoLimite(50);

        }

        public List<string> ListaErros { get; set; }
        public string PrimeiroNome { get;  set; }
        public string UltimoNome { get; set; }


        protected void PrimeiroNomeDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(PrimeiroNome)) ListaErros.Add("Primerio nome deve ser preenchido!");
        }

        protected void PrimeiroNomeDeveTerUmTamanhoLimite(int tamanho)
        {
            if (!string.IsNullOrEmpty(PrimeiroNome) && PrimeiroNome.Trim().Length > tamanho) ListaErros.Add("O campo primeiro nome deve ter no máximo " + tamanho + " caracteres!");
        }

        protected void UltimoNomeDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(UltimoNome)) ListaErros.Add("Ultimo nome deve ser preenchido!");
        }

        protected void UltimoNomeDeveTerUmTamanhoLimite(int tamanho)
        {
            if (!string.IsNullOrEmpty(UltimoNome) && UltimoNome.Trim().Length > tamanho) ListaErros.Add("O campo ultimo nome deve ter no máximo " + tamanho + " caracteres!");
        }



    }
}