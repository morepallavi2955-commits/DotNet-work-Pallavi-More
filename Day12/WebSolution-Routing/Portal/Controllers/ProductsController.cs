using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;

namespace Portal.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var products = new List<Product>
        {
            new Product {Id = 1, Title = "ABC", Price = 123},
            new Product {Id = 2, Title = "XYZ", Price = 234}
        };
        return View(products);
    }

}