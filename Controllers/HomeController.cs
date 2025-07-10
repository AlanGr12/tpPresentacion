using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tpPresentacion.Models;

namespace tpPresentacion.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]

    public IActionResult Login(string email, string contraseña){

        int id = BD.Login(email, contraseña);
        if (id != -1)
        {
            HttpContext.Session.SetInt32("IdUsuario", id);
            return RedirectToAction("Menu");
        }
        else
        {
            ViewBag.Error = "Email o contraseña incorrectos";
            return View("Index");
        }
    }

    public IActionResult Menu()
    {
        if (!HttpContext.Session.Keys.Contains("IdUsuario"))
        {
            return RedirectToAction("Index");
        }

        int id = HttpContext.Session.GetInt32("IdUsuario").Value;

        DatoPersonal usuario = BD.GetUsuario(id);

        if (usuario == null)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        return View(usuario);
    }
    public IActionResult MostrarDatosFamiliares(){

        if (!HttpContext.Session.Keys.Contains("IdUsuario"))
        {
            return RedirectToAction("Index");
        }

        int id = HttpContext.Session.GetInt32("IdUsuario").Value;
        List<DatoFamiliar> familiares = BD.GetDatoFamiliar(id);
        return View(familiares);
    }

    public IActionResult MostrarDatosInteres(){
         if (!HttpContext.Session.Keys.Contains("IdUsuario"))
        {
            return RedirectToAction("Index");
        }

        int id = HttpContext.Session.GetInt32("IdUsuario").Value;
        List<DatoInteres> intereses = BD.GetDatoInteres(id);
        return View(intereses);
    }
}
