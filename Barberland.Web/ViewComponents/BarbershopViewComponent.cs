using System;
using Barberland.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Barberland.Web.ViewComponents
{
	public class BarbershopViewComponent : ViewComponent
    {
		public BarbershopViewComponent()
		{
		}

        public IViewComponentResult Invoke(List<Barbershop> barbershops/*, int Page = 1, int TotalPages = 1, bool IsShowPagination = true*/, string viewName)
        {
            //ArtworkListComponentViewModel ViewModel = new();

            //ViewModel.Page = Page;
            //ViewModel.TotalPages = TotalPages;
            //ViewModel.IsShowPagination = IsShowPagination;
            //ViewModel.Artworks = Artworks;

            if (viewName == "HomeIndex")
            {
                return View("HomeIndexList", barbershops);
            }
            //else
            //{
            //    return View("ArtworkList", ViewModel);
            //}

            return View("HomeIndexList", new List<Barbershop>());
        }
    }
}

