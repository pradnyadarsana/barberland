using System;
using Barberland.Data.Entity;
using Barberland.Model;
using Microsoft.AspNetCore.Mvc;

namespace Barberland.Web.ViewComponents
{
	public class ServiceCategoryViewComponent : ViewComponent
    {
		public ServiceCategoryViewComponent()
		{
		}

        public IViewComponentResult Invoke(string viewName, List<ServiceCategoryIndexModel> serviceCategories, int pageNumber = 1, int totalPages = 1, bool isShowPagination = true)
        {
            ServiceCategoryComponentViewModel viewModel = new();

            viewModel.PageNumber = pageNumber;
            viewModel.TotalPages = totalPages;
            viewModel.IsShowPagination = isShowPagination;
            viewModel.ServiceCategories = serviceCategories;

            if (viewName == "HomeIndex")
            {
                return View("HomeIndexList", viewModel);
            }

            return View("HomeIndexList", viewModel);
        }
    }
}

