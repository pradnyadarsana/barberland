using System;
using Barberland.Data.Entity;

namespace Barberland.Data.Repository
{
    public interface IServiceCategoryRepository : IBaseRepository<ServiceCategory>
    {
    }

    public class ServiceCategoryRepository : BaseRepository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(DataContext context) : base(context)
        {
        }
    }
}

