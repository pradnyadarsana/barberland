using System;
namespace Barberland.Data.Entity
{
	public class ServiceCategoryImage : BaseEntity
	{
		public required Guid ServiceCategoryId { get; set; }
		public required string ImageUrl { get; set; }
		public required bool IsThumbnail { get; set; }
		public required int SortOrder { get; set; }	

		public virtual required ServiceCategory ServiceCategory { get; set; }
    }
}