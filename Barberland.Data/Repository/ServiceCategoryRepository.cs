using System;
using Barberland.Data.Entity;

namespace Barberland.Data.Repository
{
    public interface IServiceCategoryRepository : IBaseRepository<ServiceCategory>
    {
        IQueryable<ServiceCategory> GetByBarbershopId(Guid barbershopId);
        ServiceCategory? GetByPermalink(string permalink);
    }

    public class ServiceCategoryRepository : BaseRepository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(DataContext context) : base(context)
        {
        }

        public IQueryable<ServiceCategory> GetByBarbershopId(Guid barbershopId)
        {
            return context.ServiceCategories.Where(x => x.BarbershopId == barbershopId && !x.IsDeleted);
        }

        public ServiceCategory? GetByPermalink(string permalink)
        {
            return context.ServiceCategories.FirstOrDefault(x => x.Permalink == permalink && !x.IsDeleted);
        }
    }
}

