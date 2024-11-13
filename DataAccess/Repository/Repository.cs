using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }
    
    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    public T Save(T entity)
    {
        if (entity.CreationTime == entity.ModificationTime)
        {
            entity.init();
            var result = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return result.Entity;
        }
        else
        {
            entity.ModificationTime = DateTime.UtcNow;
            var result = _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return result.Entity;
        }
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();
    }
}