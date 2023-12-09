using System;
namespace Barberland.Data.Entity
{
	public class Customer : BaseEntity
	{
		public required string Name { get; set; }
		public required string Email { get; set; }
		public required string Mobile { get; set; }
		public required string Username { get; set; }
		public required string Password { get; set; }
	}
}

