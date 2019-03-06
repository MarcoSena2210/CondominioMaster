using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioMaster.Domain.DTO
{
    public class EdificacaoDTO
    {
        public int Id { get; set; }
        public string NomeCondominio { get; set; }
        public string CPFCNPJ { get; set; }
        public string NomeEdificacao { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string NomeResponsavelFinanciro { get; set; } 
        public string NumeroPorta { get; set; } //4a ou 401
        public string Identificador { get; set; } 
    }
}
