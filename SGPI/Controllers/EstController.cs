using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGPI.Controllers
{
    public class EstController : Controller
    {
        public IActionResult PerfilEst()
        {
            return View();
        }
        public IActionResult PagoMatriculaEst()
        {
            return View();
        }
    }
   
}
