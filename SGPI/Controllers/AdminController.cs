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

            ViewBag.genero = context.Generos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.tipodocumento = context.TipoDocumentos.ToList();

            return View();
        }


        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {

            context.Add(usuario);
            context.SaveChanges();
            ViewBag.genero = context.Generos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.tipodocumento = context.TipoDocumentos.ToList();

            string rol = "";
            if (usuario.IdRol == 1)
            {
                rol = "Admin"; 
            } 
            else if(usuario.IdRol == 2)
            {
                rol = "Coordi";
            } 
            else if (usuario.IdRol == 3)
            {
                rol = "Est";
            }

            return RedirectToAction("Administrador");
        }


        public IActionResult BuscarUsuario()
        {
            Usuario us = new Usuario();
            return View(us);
        }


        [HttpPost]
        public IActionResult BuscarUsuario(Usuario user)
        {
            var us = context.Usuarios.Where(u => u.Documento == user.Documento);

            if (us != null)
            {
                return View(us.SingleOrDefault());
            }
            else
            {
                return View(us);
            }

        }


        public IActionResult EditarUsuario(int Idusuario)
        {
            Usuario usuario = context.Usuarios.Find(Idusuario);
            if (usuario == null)
            {
                return NotFound();
            }

            ViewBag.genero = context.Generos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.tipodocumento = context.TipoDocumentos.ToList();
            ViewBag.idusuario = Idusuario;

            return View(usuario);
        }


        [HttpPost]
        public IActionResult EditarUsuario(Usuario user, int idUsuario)
        {
            user.IdUsuario = idUsuario;
            context.Update(user);
            context.SaveChanges();

            return View("Administrador");
        }


        public IActionResult Eliminar(Usuario user)
        {
            Usuario usuario = context.Usuarios.Find(user.IdUsuario);
            if (usuario == null)
            {
                return ViewBag.mensaje = "Error al eliminar usuario";
            }
            else
            {
                context.Remove(usuario);
                context.SaveChanges();
            }

            return RedirectToAction("BuscarUsuario");
        }


        public IActionResult InformeUsuario()
        {
            return View();
        }

    }  
}
