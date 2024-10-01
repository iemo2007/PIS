using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.Repositories.GenericRepo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T Get(params object[] id)
        {
            return _context.Set<T>().Find(id);
        }

        public T FilterFirst(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public T Add(T entity)
        {
            var addedEntity = _context.Set<T>().Add(entity);
            return (entity != null) ? entity : null;
        }

        public T update(T entity)
        {
            var updatedEntity = _context.Set<T>().Update(entity);
            return (entity != null) ? entity : null;
        }

        public bool Delete(T entity)
        {
            var removedEntity = _context.Set<T>().Remove(entity);
            return (removedEntity != null);
        }

        public void RemoveRange(IQueryable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void AddRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
    }
}
