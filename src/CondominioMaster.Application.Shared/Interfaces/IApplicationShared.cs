
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace CondominioMaster.Application.Shared.Interfaces
{
     public interface IApplicationShared : IDisposable
     {
          SelectList ObterSiglaImovel();
     }
}
