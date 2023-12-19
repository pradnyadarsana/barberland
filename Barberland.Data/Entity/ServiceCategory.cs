using System;
namespace Barberland.Data.Entity
{
	public class ServiceCategory : BaseEntity
	{
        public required Guid BarbershopId { get; set; }
        public required string Name { get; set; }
        public required string Permalink { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public required TimeSpan DurationEst { get; set; }

        public virtual required Barbershop Barbershop { get; set; }
        public virtual ICollection<ServiceCategoryImage>? ServiceCategoryImages { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}

