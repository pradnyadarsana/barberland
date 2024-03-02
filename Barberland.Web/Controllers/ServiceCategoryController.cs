using System;
using Barberland.Model;
using Barberland.Service;
using Microsoft.AspNetCore.Mvc;

namespace Barberland.Web.Controllers
{
	public class ServiceCategoryController : Controller
	{
        private readonly ILogger<ServiceCategoryController> _logger;
        private readonly IServiceCategoryService _serviceCategoryService;

        public ServiceCategoryController(ILogger<ServiceCategoryController> logger, IServiceCategoryService serviceCategoryService)
		{
            _logger = logger;
            _serviceCategoryService = serviceCategoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(string barbershopPermalink, string serviceCategoryPermalink)
        {
            string barbershopServicePermalink = barbershopPermalink + "/" + serviceCategoryPermalink;
            ResponseModel<ServiceCategoryDetailViewModel> responseModel = _serviceCategoryService.GetServiceDetailDataModel(barbershopServicePermalink);

            if (responseModel.StatusCode == 404)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return View(responseModel.Object);
        }
	}
}

