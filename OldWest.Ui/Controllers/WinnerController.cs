using Microsoft.AspNetCore.Mvc;
using OldWest.Ui.Models;

namespace OldWest.Ui.Controllers;

public class WinnerController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult HandleSubmit(User model)
    {
        return View(!ModelState.IsValid ? "Index" : "Summary", model);
    }

    [HttpPost]
    public IActionResult Redirect()
    {
        return RedirectToAction("Index", "Home");
    }
}