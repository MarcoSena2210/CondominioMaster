using System;

namespace CondominioMaster.UI.Site.MVC.Models
{
     public class ErrorViewModel
     {
          public string RequestId { get; set; }

          public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
     }
}