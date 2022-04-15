using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGPI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Administrador()
        {
            return View();
        }
        public IActionResult AdministrarUsuario()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            return View();
        }     
  public IActionResult BuscarUsuario()
        {
            return View();
        }

        public IActionResult InformeUsuario()
        {
            return View();
        }

    }  
}
