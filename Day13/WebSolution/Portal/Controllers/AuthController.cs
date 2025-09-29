
namespace Portal.Controllers;

using Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using Repositories;

//it provides enum, classes, interfaces,
//delegates, events for building ASP.NET Core applications.
public class AuthController : Controller
{
    //Dependency Injection for ICustomerService, CustomerService
    private readonly ICustomerService _customerService;
    public AuthController(ICustomerService CustomerService)
    {
        _customerService = CustomerService;
    }


    [HttpGet]   //attribute , Decorator, Annotation, Metadata
                //Action Filter
    public IActionResult Login()
    {
        return View();
    }


    // [HttpPost]
    //  public IActionResult Login(string email, string password)
    // {

    //     if (email == "a@gmail.in" && password == "seed")
    //     {
    //         this.Response.Redirect("/home/index");
    //         //this.Response.Redirect("/products/index");
    //     }
    //     return View();
    // }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var customers = _customerService.GetAllCustomers();

        var customer = customers.FirstOrDefault(c =>
        c.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
        && c.Password == password);
        if (customer != null)
        {
            this.Response.Redirect("/product");
        }

        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
    
      [HttpPost]
    public IActionResult Register(string name, string email, string password)
    {
        var customers = _customerService.GetAllCustomers();
        var existingCustomer = customers.FirstOrDefault(c =>
            string.Equals(c.Email, email, StringComparison.OrdinalIgnoreCase));

        if (existingCustomer != null)
        {
            ViewBag.ErrorMessage = "User already exists with this email address.";
            return View();
        }

        var names = name.Split(' ', 2);
        string firstName = names[0];
        string lastName = names.Length > 1 ? names[1] : "";
        var newCustomer = new Customer
        {
            Id = customers.Any() ? customers.Max(c => c.Id) + 1 : 1,
            FistName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _customerService.AddCustomer(newCustomer);

        this.Response.Redirect("/auth/login");
      return View();
}

}