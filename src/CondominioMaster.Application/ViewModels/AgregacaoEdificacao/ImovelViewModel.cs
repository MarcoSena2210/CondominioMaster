using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CondominioMaster.Application.ViewModels.AgregacaoEdificacao
{
    public class ImovelViewModel
    {
        public ImovelViewModel()
        {
            ListaErros = new List<string>();
        }

        public int Id { get; set; }
        public List<string> ListaErros { get; set; }

        public string NomeEdificacao { get; set; }

        [Required(ErrorMessage = "Id da edificacao é obrigatório!")]
        public int IdEdificacao { get; set; }

        [Required(ErrorMessage = "Id da edificacao é obrigatório!")]
        public int IdPessoaFinanceiro { get; set; }  //Pessoa Responsavel Financeiro
        public string ResponsavelFinanceiro { get; set; }
     
        [Required(ErrorMessage = "Número da porta é obrigatório!")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres!")]
        public string NumeroPorta { get; set; } //4a ou 401

        [Required(ErrorMessage = "Identificador do imovel é obrigatório!")]
        public string Identificador { get; set; } // id.condomio + Id.Edificacao + Sigla + Numero do Apartamento 

        [Required(ErrorMessage = "Sigla do tipo de imóvel é obrigatório!")]
        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres!")]
        public string SiglaImovel { get; set; } //AP,LO,CA,TE,GA,


    }
}
