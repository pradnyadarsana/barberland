using System;
using System.Reflection.Metadata;
using Barberland.Web.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Barberland.Web.ViewComponents
{
	public class WidgetViewComponent : ViewComponent
	{
		public WidgetViewComponent()
		{
		}

        public IViewComponentResult Invoke(string ViewName)
        {
            object ViewModel;
            if (ViewName == "NavigationBar")
            {
                ViewModel = new NavigationBarViewModel();
            }
            else if (ViewName == "Footer")
            {
                ViewModel = PopulateFooterViewModel();
            }
            else
            {
                ViewModel = new object();
            }
            return View(ViewName, ViewModel);
        }

        private static FooterViewModel PopulateFooterViewModel()
        {
            FooterViewModel ViewModel = new()
            {
                FooterDescription = "Test Footer Description",
                FooterContactMobile = "089123456789",
                FooterContactEmail = "testemail@gmail.com",
                FooterCopyright = "Barberland 2023",
                FacebookURL = "https://facebook.com",
                TwitterURL = "https://x.com",
                InstagramURL = "https://instagram.com"
            };

            return ViewModel;
        }
    }
}

