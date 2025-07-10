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
}
