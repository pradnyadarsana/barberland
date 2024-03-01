using System;
using System.Xml.Linq;
using Barberland.Data.Entity;

namespace Barberland.Data.Repository
{
    public interface IBarbershopRepository : IBaseRepository<Barbershop>
    {
        IQueryable<Barbershop> GetByNameLike(string name);
        Barbershop? GetByPermalink(string permalink);
    }

    public class BarbershopRepository : BaseRepository<Barbershop>, IBarbershopRepository
    {
        public BarbershopRepository(DataContext context) : base(context)
        {
        }

        public IQueryable<Barbershop> GetByNameLike(string name)
        {
            return context.Barbershops.Where(x => x.Name.Contains(name));
        }

        public Barbershop? GetByPermalink(string permalink)
        {
            return context.Barbershops.Where(x => x.Permalink.ToLower() == permalink.ToLower()).FirstOrDefault();
        }
    }
}

