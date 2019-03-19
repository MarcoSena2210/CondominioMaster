using CondominioMaster.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CondominioMaster.UI.Site.MVC.Areas.Cadastro.Controllers
{
     public class EmpresasController : Controller
     {
          private readonly IApplicationEmpresa appEmpresas;

          public EmpresasController(IApplicationEmpresa _appEmpresas)
          {
               appEmpresas = _appEmpresas;
          }

          public IActionResult Index()
          {
               var model = appEmpresas.ObterTodos();
               return View(model);
          }
     }
}