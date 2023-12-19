using System;
using Barberland.Data.Entity;

namespace Barberland.Data.Repository
{
    public interface IServiceCategoryImageRepository : IBaseRepository<ServiceCategoryImage>
    {
        IQueryable<ServiceCategoryImage> GetByServiceCategoryId(Guid serviceCategoryId);
    }

    public class ServiceCategoryImageRepository : BaseRepository<ServiceCategoryImage>, IServiceCategoryImageRepository
	{
		public ServiceCategoryImageRepository(DataContext context) : base(context)
        {
        }

        public IQueryable<ServiceCategoryImage> GetByServiceCategoryId(Guid serviceCategoryId)
        {
            return context.ServiceCategoryImages.Where(x => x.ServiceCategoryId == serviceCategoryId);
        }
    }
}

