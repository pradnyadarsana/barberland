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