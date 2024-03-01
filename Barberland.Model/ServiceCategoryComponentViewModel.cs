using System;
namespace Barberland.Model
{
	public class ServiceCategoryComponentViewModel
	{
		public List<ServiceCategoryIndexModel> ServiceCategories { get; set; }
        public int PageNumber { get; set; }
        public int DataPerPage { get; set; }
        public int TotalPages { get; set; }
        public bool IsShowPagination { get; set; }
    }
}

