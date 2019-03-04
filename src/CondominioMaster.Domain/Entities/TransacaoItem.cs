using CondominioMaster.Domain.Shared.Entities;
using System.Linq;

namespace CondominioMaster.Domain.Entities
{
    public class TransacaoItem : EntidadeBase
    {
        public override bool EstaConsistente()
        {
            DescricaoDeveSerPreenchido();
            DescricaoDeveTerUmTamanhoLimite();
            return !ListaErros.Any();
        }

        public string Descricao { get; set; }

        private void DescricaoDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Descricao)) ListaErros.Add("O campo descrição deve ser preenchido!");
        }

        private void DescricaoDeveTerUmTamanhoLimite()
        {
            if (Descricao.Length > 50) ListaErros.Add("O campo descrição deve ter no máximo 50 caracteres!");
        }



    }
}
