using System;
using Barberland.Data.Entity;

namespace Barberland.Model
{
	public class BarbershopIndexViewModel
	{
		public string? MainHeaderBannerUrl { get; set; }
		public string HeaderTitleText { get; set; }
		public string HeaderSubtitleText { get; set; }
		public List<Barbershop> Barbershops { get; set; }
		public int PageNumber { get; set; }
		public int DataPerPage { get; set; }
		public int TotalPages { get; set; }
	}
}

