using System;
using Barberland.Data.Entity;

namespace Barberland.Data.Repository
{
    public interface IBarbershopRepository : IBaseRepository<Barbershop>
    {
    }

    public class BarbershopRepository : BaseRepository<Barbershop>, IBarbershopRepository
    {
        public BarbershopRepository(DataContext context) : base(context)
        {
        }
    }
}

