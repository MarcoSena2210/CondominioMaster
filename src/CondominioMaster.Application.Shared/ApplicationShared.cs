using CondominioMaster.Application.Shared.Interfaces;
using CondominioMaster.Domain.Shared.ValueObjects;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace CondominioMaster.Application.Shared
{
     public class ApplicationShared : IApplicationShared
     {
          

          public SelectList ObterSiglaImovel()
          {
               SiglaImovelVO objSigla = new SiglaImovelVO();
               var uSigla = objSigla.ObterSiglaImovel();
               var ret = new SelectList(uSigla, "Sigla", "Sigla", "AP");
               return ret;
          }

          public void Dispose()
          {
               GC.SuppressFinalize(this);
          }
     }
}
