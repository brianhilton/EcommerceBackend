namespace EcommerceBackend.Data.Repository;

public interface IGenericRepository<T>
{
    public T? Single(int key);

    public IQueryable<T> GetAll();

    public bool Exists(int key);

    public void Insert(T entity);

    public void Delete(T entity);

    public void SaveChanges();

    public void DeleteChanges();
}