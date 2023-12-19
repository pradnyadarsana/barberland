using Barberland.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Barberland.Data
{
    public class DataContext : DbContext
    {
        //public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Barbershop> Barbershops { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceCategoryImage> ServiceCategoryImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Remove(typeof(TableNameFromDbSetConvention));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    //new AuthorMap(modelBuilder.Entity<Author>());
        //    //new BookMap(modelBuilder.Entity<Book>());
        //}
    }
}