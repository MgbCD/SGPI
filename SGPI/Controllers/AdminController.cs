using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGPI.Controllers
{
   
    public class AdminController : Controller
    {
        private SGPI_DBContext context;

        public AdminController (SGPI_DBContext contexto)
        {
            context = contexto;
        }
            public IActionResult Administrador()
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
