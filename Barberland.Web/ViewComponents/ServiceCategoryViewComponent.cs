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

        public IViewComponentResult Invoke(List<ServiceCategoryIndexModel> serviceCategories/*, int Page = 1, int TotalPages = 1, bool IsShowPagination = true*/, string viewName)
        {
            //ArtworkListComponentViewModel ViewModel = new();

            //ViewModel.Page = Page;
            //ViewModel.TotalPages = TotalPages;
            //ViewModel.IsShowPagination = IsShowPagination;
            //ViewModel.Artworks = Artworks;

            if (viewName == "HomeIndex")
            {
                return View("HomeIndexList", serviceCategories);
            }
            //else
            //{
            //    return View("ArtworkList", ViewModel);
            //}

            return View("HomeIndexList", new List<ServiceCategoryIndexModel>());
        }
    }
}

