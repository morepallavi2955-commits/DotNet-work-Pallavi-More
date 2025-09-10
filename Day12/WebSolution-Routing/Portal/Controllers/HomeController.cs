using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;

namespace Portal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    //Action Method
    //Home/Index
    //HTTP GET
    public IActionResult Index()
    {
        string message = "HI Hello How r you??";
        return View();//Genearting view result object and returning to caller
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Customer()
    {
        return View();
    }

    public IActionResult About()
    {
        string message = "Our mission to help people.";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
