using System;
namespace Barberland.Data.Entity
{
	public class OrderDetail : BaseEntity
	{
        public Guid OrderId { get; set; }
        public Guid ServiceCategoryId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public required TimeSpan DurationEst { get; set; }

        public virtual required Order Order { get; set; }
        public virtual required ServiceCategory ServiceCategory { get; set; }
    }
}

