using Microsoft.EntityFrameworkCore;

namespace Barberland.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext context;
        protected DbSet<T> entities;
        //string errorMessage = string.Empty;

        public BaseRepository(DataContext context)
        {
            this.context = context;
            entities = context.Set<T>();

        }

        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable();
        }

        public T? Find(Guid id)
        {
            return entities.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}

