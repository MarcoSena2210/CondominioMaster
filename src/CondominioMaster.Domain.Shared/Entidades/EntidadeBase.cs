using System.Collections.Generic;

namespace CondominioMaster.Domain.Shared.Entidades
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            ListaErros = new List<string>();
        }
        public int Id { get; set; }
        public List<string> ListaErros { get; set; }
        public abstract bool EstaConsistente();
    }
}
