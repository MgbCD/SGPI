using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SGPI.Controllers
{
    public class CoordiController : Controller
    {
        public IActionResult Coordinador()
        {
            return View();
        }
        public IActionResult CoordinadorConsulta()
        {
            return View();
        }
        public IActionResult CoordinadorEntrevista()
        {
            return View();
        }
        public IActionResult CoordinadorHomologar()
        {
            return View();
        }
        public IActionResult CoordinadorProgramarAsignatura()
        {
            return View();
        }
    }
}
