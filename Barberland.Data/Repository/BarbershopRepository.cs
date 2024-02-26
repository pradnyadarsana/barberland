using System;
using Barberland.Data.Entity;

namespace Barberland.Data.Repository
{
    public interface IBarbershopRepository : IBaseRepository<Barbershop>
    {
        IQueryable<Barbershop> GetByName(string name);
    }

    public class BarbershopRepository : BaseRepository<Barbershop>, IBarbershopRepository
    {
        public BarbershopRepository(DataContext context) : base(context)
        {
        }

        public IQueryable<Barbershop> GetByName(string name)
        {
            return context.Barbershops.Where(x => x.Name.Contains(name));
        }
    }
}

