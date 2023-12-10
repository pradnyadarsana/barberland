using System;
namespace Barberland.Web.Models
{
	public class WidgetViewModel
	{
		public WidgetViewModel()
		{
		}
	}

    public class NavigationBarViewModel
    {
    }

    public class FooterViewModel
    {
        public required string FooterDescription { get; set; }
        public required string FooterContactMobile { get; set; }
        public required string FooterContactEmail { get; set; }
        public required string FooterCopyright { get; set; }
        public required string FacebookURL { get; set; }
        public required string TwitterURL { get; set; }
        public required string InstagramURL { get; set; }
    }
}

