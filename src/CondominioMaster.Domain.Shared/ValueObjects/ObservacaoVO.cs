using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioMaster.Domain.Shared.ValueObjects
{
    public class ObservacaoVO
    {
        public ObservacaoVO()
        {
            ObservacaoDeveTerUmTamanhoMinimo(5);
            ObservacaoDeveTerUmTamanhoLimite(400);
        }

        protected void ObservacaoDeveTerUmTamanhoMinimo(int tamanho)
        {
            if (!string.IsNullOrEmpty(Observacao) && Observacao.Trim().Length < tamanho) ListaErros.Add("O campo observação deve ter no mínimo " + tamanho + " caracteres!");
        }

        protected void ObservacaoDeveTerUmTamanhoLimite(int tamanho)
        {
            if (!string.IsNullOrEmpty(Observacao) && Observacao.Trim().Length > tamanho) ListaErros.Add("O campo observação deve ter no máximo " + tamanho + " caracteres!");
        }

        public List<string> ListaErros { get; set; }
        public string Observacao { get; set; }
    }
}
