using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.Repositories.GenericRepo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(params object[] id);
        TEntity FilterFirst(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity update(TEntity entity);
        bool Delete(TEntity entity);

        void RemoveRange(IQueryable<TEntity> entities);
        void AddRange(List<TEntity> entities);
    }
}
