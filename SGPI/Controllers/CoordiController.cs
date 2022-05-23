using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SGPI.Controllers
{
    public class CoordiController : Controller
    {
        private SGPI_DBContext context;

        public CoordiController(SGPI_DBContext contexto)
        {
            context = contexto;
        }

        public IActionResult Coordinador()
        {
            return View();
        }

        public IActionResult CoordinadorConsulta()
        {
            Usuario us = new Usuario();

            ViewBag.programa = context.Programas.ToList();

            return View(us);
        }


        [HttpPost]
        public IActionResult CoordinadorConsulta(Usuario user)
        {
            ViewBag.programa = context.Programas.ToList();

            var us = context.Usuarios.Where(u => u.Documento == user.Documento && u.IdRol == 3 && u.IdPrograma == user.IdPrograma);

            if (us != null)
            {
                return View(us.SingleOrDefault());
            }
            else
            {
                return View(us);
            }

        }

        public IActionResult CoordinadorEntrevista()
        {
            ViewBag.genero = context.Generos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.tipodocumento = context.TipoDocumentos.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult CoordinadorEntrevista(Usuario usuario)
        {

            context.Add(usuario);
            context.SaveChanges();
            context.Add(new Entrevista() { IdUsuario = usuario.IdUsuario, FechaEntrevista = DateTime.Now, Estado = "En revisión" });
            context.SaveChanges();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.tipodocumento = context.TipoDocumentos.ToList();

            return RedirectToAction("Coordinador");
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
