using Microsoft.AspNetCore.Mvc;

namespace SkyCast.WebSystem.Controllers;

public class SkyCastController : Controller
{
    public IActionResult SkyCastIndex()
    {
        return View();
    }
}
