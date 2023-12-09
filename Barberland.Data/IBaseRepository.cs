namespace Barberland.Data;

public interface IBaseRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    T? Find(Guid id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
}
