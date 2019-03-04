using CondominioMaster.Domain.Shared.Enums;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Shared.Entities
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            DataIncluiRegistro = DateTime.Now;
            StatusRegistro = EStatusRegistro.Ativo.ToString();
            ListaErros = new List<string>();
        }
        public DateTime DataIncluiRegistro { get; set; }
        public int Id { get; set; }
        public string  StatusRegistro { get; set; }
        public List<string> ListaErros { get; set; }
        public abstract bool EstaConsistente();
    }
}
