﻿using System;
using Barberland.Model;
using Barberland.Service;
using Microsoft.AspNetCore.Mvc;

namespace Barberland.Web.Controllers
{
	public class BarbershopController : Controller
	{
        private readonly ILogger<BarbershopController> _logger;
        private readonly IBarbershopService _barbershopService;

        public BarbershopController(ILogger<BarbershopController> logger, IBarbershopService barbershopService)
		{
			_logger = logger;
            _barbershopService = barbershopService;
		}

        [HttpGet]
        public IActionResult Index()
        {
            #region Create Pagination Model
            PaginationModel paginationModel = new();
            bool isPageParsed = int.TryParse(Request.Query["page"], out int pageNumber);
            paginationModel.PageNumber = isPageParsed ? pageNumber : 1;
            paginationModel.DataPerPage = 10;
            #endregion

            #region Create Search Model
            SearchModel? searchModel = !string.IsNullOrEmpty(Request.Query["searchtext"]) || !string.IsNullOrEmpty(Request.Query["orderby"]) ?
                    new()
                    {
                        SearchText = Request.Query["searchtext"],
                        OrderBy = Request.Query["orderby"]
                    } : null;
            #endregion

            BarbershopIndexViewModel viewModel = new();
            viewModel = _barbershopService.GetIndexDataModel(paginationModel, searchModel);

            return View(viewModel);
        }
    }
}

