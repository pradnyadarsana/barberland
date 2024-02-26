using System;
namespace Barberland.Model
{
	public class PaginationModel
	{
		public int PageNumber { get; set; }
		public int DataPerPage { get; set; }
		public int TotalPages { get; set; }
	}
}

