using Demo.DataAccess.Models.EmployeeModule;
using Demo.DataAccess.Models.Shared;
using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepositorie<TEntity>  where TEntity : BaseEntity 
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity,bool>> Predicate);

        TEntity? GetById(int id);
        void Remove(TEntity entity);
        void Update(TEntity entity);

        //IEnumerable<TEntity> GetIEnumerable();
        
        //IQueryable<TEntity> GetIQueryable();
    }
}
