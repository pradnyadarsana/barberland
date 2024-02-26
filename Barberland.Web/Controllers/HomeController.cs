using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Barberland.Web.Models;
using Barberland.Model;
using Barberland.Service;

namespace Barberland.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHomePageService _homePageService;

    public HomeController(ILogger<HomeController> logger, IHomePageService homePageService)
    {
        _logger = logger;
        _homePageService = homePageService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        HomeIndexViewModel indexViewModel = new();
        indexViewModel = _homePageService.GetIndexDataModel();

        return View(indexViewModel);
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

