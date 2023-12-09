using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Barberland.Web.Models;
using Barberland.Data.Entity;
using Barberland.Data.Repository;
using Barberland.Data;

namespace Barberland.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICustomerRepository _customerRepository;

    public HomeController(ILogger<HomeController> logger, ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public IActionResult Index()
    {
        List<Customer> customers = _customerRepository.GetAll().ToList();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

