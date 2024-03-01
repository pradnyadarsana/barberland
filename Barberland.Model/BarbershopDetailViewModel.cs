using System;
using Barberland.Data.Entity;

namespace Barberland.Model
{
	public class BarbershopDetailViewModel
	{
        public Barbershop Barbershop { get; set; }

        public List<ServiceCategoryIndexModel> ServiceCategories { get; set; }
        public int ServicePageNumber { get; set; }
        public int ServiceDataPerPage { get; set; }
        public int ServiceTotalPages { get; set; }

        public string GoogleAPIKey { get; set; }
    }
}

