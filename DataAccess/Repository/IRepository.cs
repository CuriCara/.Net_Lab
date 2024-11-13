namespace DataAccess.Repository;

using DataAccess.Entity;

public interface IRepository<T> where T : BaseEntity
{
        IQueryable<T> GetAll();

        T? GetById(int id);

        T Save(T entity);

        void Delete(T entity);
    
}