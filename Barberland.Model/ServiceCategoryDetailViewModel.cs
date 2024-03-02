using System;
using Barberland.Data.Entity;

namespace Barberland.Model
{
	public class ServiceCategoryDetailViewModel
	{
		public Barbershop Barbershop { get; set; }
		public ServiceCategory ServiceCategory { get; set; }
		public List<ServiceCategoryImage> ServiceCategoryImages { get; set; }
	}
}

