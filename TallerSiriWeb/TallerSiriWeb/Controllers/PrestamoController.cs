using Microsoft.AspNetCore.Mvc;
using TallerSiriWeb.Datos;
using TallerSiriWeb.Models;

namespace TallerSiriWeb.Controllers
{
    public class PrestamoController : Controller
    {
        PresmoDatos _PrestamoDatos = new PresmoDatos();
        public IActionResult Listar()
        {
            var lista = _PrestamoDatos.Listar();
            return View(lista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PrestamoModel prestamo)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _PrestamoDatos.Guardar(prestamo);

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
            var prestamo = _PrestamoDatos.Obtener(id);
            return View(prestamo);
        }

        [HttpPost]
        public IActionResult Editar(PrestamoModel prestamo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _PrestamoDatos.Editar(prestamo);

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

            var prestamo = _PrestamoDatos.Obtener(id);
            return View(prestamo);

        }
        [HttpPost]
        public IActionResult Eliminar(PrestamoModel prestamo)
        {

            var respuesta = _PrestamoDatos.Eliminar(prestamo.id);

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
