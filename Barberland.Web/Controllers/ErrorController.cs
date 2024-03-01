using System;
using Microsoft.AspNetCore.Mvc;

namespace Barberland.Web.Controllers
{
	public class ErrorController : Controller
	{
        public ErrorController()
        {

        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            int statusCode = id;

            if(statusCode == 404)
            {
                return View("PageNotFound");
            }
            return View();
        }
    }
}

