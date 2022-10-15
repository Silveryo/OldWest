using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OldWest.Ui.Models;
using OldWest.Ui.Helpers;

namespace OldWest.Ui.Controllers;

public class HomeController : Controller
{
    private const string BulletCountKey = SessionHelper.BulletCountSessionKey;
    private int _bulletCount = 12;

    [HttpGet]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32(SessionHelper.BulletCountSessionKey) != null)
        {
            _bulletCount = ((int)HttpContext.Session.GetInt32(BulletCountKey));
        }

        ViewBag.bulletCount = _bulletCount;

        return View();
    }

    [HttpGet]
    public IActionResult Shop()
    {
        return View("Shop");
    }

    public IActionResult Shoot()
    {
        if (HttpContext.Session.GetInt32(SessionHelper.BulletCountSessionKey) != null)
        {
            _bulletCount = (int)HttpContext.Session.GetInt32(SessionHelper.BulletCountSessionKey);
        }

        _bulletCount--;
        HttpContext.Session.SetInt32("_BulletCount", _bulletCount);

        if (_bulletCount == 0)
        {
            return View("Shop");
        }

        var rng = new Random();
        int roll = rng.Next(0, 10);

        return roll <= 3 ? View("~/Views/Winner/Index.cshtml") : RedirectToAction("Index");
    }

    public IActionResult Reload(int buyCount)
    {
        if (HttpContext.Session.GetInt32(SessionHelper.BulletCountSessionKey) != null)
        {
            HttpContext.Session.SetInt32(SessionHelper.BulletCountSessionKey,
                (int)HttpContext.Session.GetInt32(SessionHelper.BulletCountSessionKey) + buyCount);
        }

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}