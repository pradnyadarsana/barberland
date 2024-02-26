using System;
using Barberland.Data.Entity;
using Barberland.Model;
using Microsoft.AspNetCore.Mvc;

namespace Barberland.Web.ViewComponents
{
	public class BarbershopViewComponent : ViewComponent
    {
		public BarbershopViewComponent()
		{
		}

        public IViewComponentResult Invoke(string viewName, List<Barbershop> barbershops, int pageNumber = 1, int totalPages = 1)
        {
            if (viewName == "HomeIndexList")
            {
                return View(viewName, barbershops);
            }
            else if(viewName == "BarbershopIndexList")
            {
                BarbershopIndexViewModel viewModel = new();
                viewModel.Barbershops = barbershops;
                viewModel.PageNumber = pageNumber;
                viewModel.TotalPages = totalPages;
                return View(viewName, viewModel);
            }

            return View("HomeIndexList", new List<Barbershop>());
        }
    }
}

