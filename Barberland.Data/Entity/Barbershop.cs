﻿using System;
namespace Barberland.Data.Entity
{
	public class Barbershop : BaseEntity
    {
        public required string Name { get; set; }
        public required string Permalink { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public required string Mobile { get; set; }
        public string? LogoImgUrl { get; set; }
        public required string Latitude { get; set; }
        public required string Longitude { get; set; }

        public virtual ICollection<ServiceCategory>? ServiceCategories { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}

