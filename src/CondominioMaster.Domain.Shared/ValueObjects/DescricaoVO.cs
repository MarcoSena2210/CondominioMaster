using System.Collections.Generic;

namespace CondominioMaster.Domain.Shared.ValueObjects
{
    public class DescricaoVO
    {

        public DescricaoVO()
        {
            DescricaoDeveTerUmTamanhoMinimo(5);
            DescricaoDeveTerUmTamanhoLimite(150);

        }

        protected void DescricaoDeveTerUmTamanhoMinimo(int tamanho)
        {
            if (!string.IsNullOrEmpty(Descricao) && Descricao.Trim().Length < tamanho) ListaErros.Add("O campo descrição deve ter no mínimo " + tamanho + " caracteres!");
        }

        protected void DescricaoDeveTerUmTamanhoLimite(int tamanho)
        {
            if (!string.IsNullOrEmpty(Descricao) && Descricao.Trim().Length > tamanho) ListaErros.Add("O campo e-mail deve ter no máximo " + tamanho + " caracteres!");
        }

        public List<string> ListaErros { get; set; }
        public string Descricao { get; set; }
    }
}
