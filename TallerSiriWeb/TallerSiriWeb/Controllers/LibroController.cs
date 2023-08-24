using Microsoft.AspNetCore.Mvc;
using TallerSiriWeb.Datos;
using TallerSiriWeb.Models;

namespace TallerSiriWeb.Controllers
{
    public class LibroController : Controller
    {
        LibroDatos _LibroDatos = new LibroDatos();
        public IActionResult Listar()
        {
            var lista = _LibroDatos.Listar();
            return View(lista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(LibroModel libro)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _LibroDatos.Guardar(libro);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Editar(int id)
        {
            var libro = _LibroDatos.Obtener(id);
            return View(libro);
        }

        [HttpPost]
        public IActionResult Editar(LibroModel libro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _LibroDatos.Editar(libro);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int id)
        {

            var libro = _LibroDatos.Obtener(id);
            return View(libro);

        }
        [HttpPost]
        public IActionResult Eliminar(LibroModel libro)
        {

            var respuesta = _LibroDatos.Eliminar(libro.id);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
