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

         }
        public string PrimeiroNome { get;  set; }
        public string UltimoNome { get; set; }

        //protected void PrimeiroNomeDeveSerPreenchido()
        //{
        ////  if (string.IsNullOrEmpty(PrimeiroNome)) ListaErros.Add("Primeiro nome deve ser preenchido!");
        //}

        //protected void PrimeiroNomeDeveTerUmTamanhoLimite(int tamanho)
        //{
        // // if (!string.IsNullOrEmpty(PrimeiroNome) && PrimeiroNome.Trim().Length > tamanho) ListaErros.Add("O campo  primeiro nome deve ter no máximo " + tamanho + " caracteres!");
        //}
       


    }
}