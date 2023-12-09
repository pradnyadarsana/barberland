using System;
using Barberland.Data.Entity;

namespace Barberland.Data.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }

    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }
    }
}

