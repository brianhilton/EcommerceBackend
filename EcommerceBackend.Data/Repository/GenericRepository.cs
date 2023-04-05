

using EcommerceBackend.Data.Context;
using EcommerceBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Data.Repository;

public class GenericRepository<T>:IGenericRepository<T> where T: class, IUniqueIdentifier
{
    private DataContext _context;
    
    public GenericRepository(DataContext context)
    {
        _context = context;
    }
    
    public T? Single(int key)
    {
        return _context.Set<T>().SingleOrDefault(e => e.Id == key);
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public bool Exists(int key)
    {
        return _context.Set<T>().Find(key) != null;
    }

    public void Insert(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _context.Set<T>().Attach(entity);
        }

        _context.Set<T>().Remove(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void DeleteChanges()
    {
        throw new NotImplementedException();
    }
}