using System;
namespace Barberland.Data.Entity
{
	public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid BarbershopId { get; set; }
        public required string OrderCode { get; set; }
		public DateTime OrderDate { get; set; }
		public int Status { get; set; }
        public decimal TotalPrice { get; set; }
        public TimeSpan TotalDurationEst { get; set; }

        public virtual required Customer Customer { get; set; }
        public virtual required Barbershop Barbershop { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}

