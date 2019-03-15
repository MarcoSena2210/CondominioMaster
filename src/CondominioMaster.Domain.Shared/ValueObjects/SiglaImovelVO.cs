using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioMaster.Domain.Shared.ValueObjects
{
     public class SiglaImovelVO
     {
          public string Sigla { get; set; }
          public string Descritivo { get; set; }


          public bool Validar(string Sigla)
          {
               if (!string.IsNullOrEmpty(Sigla))
               {
                    return ValidarSigla(Sigla);
               }
               return true;
          }

          private bool ValidarSigla(string Sigla)
          {
               var listaSiglas = ObterSiglaImovel();
               if (!listaSiglas.Where(x => x.Sigla == null).Any())
               {
                    return false;
               }
               return true;
          }

          public List<SiglaImovelVO> ObterSiglaImovel()
          {
               return new List<SiglaImovelVO>()
            {
                new SiglaImovelVO() {Sigla = "AP",Descritivo= "Apartamento" },
                new SiglaImovelVO() {Sigla = "CA",Descritivo= "Casa" },
               new SiglaImovelVO() {Sigla = "LO",Descritivo= "Loja" },
                new SiglaImovelVO() {Sigla = "TE",Descritivo= "Terreno" },
               new SiglaImovelVO() {Sigla = "GA",Descritivo= "Garagem" },

            };
          }
     }
}
