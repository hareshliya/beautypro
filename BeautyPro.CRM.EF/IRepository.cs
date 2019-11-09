using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BeautyPro.CRM.EF
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> All { get; }
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        void SaveChanges();
    }
}
