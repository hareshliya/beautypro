using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BeautyPro.CRM.EF
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IContextFactory _contextFactory;
        protected readonly DbSet<TEntity> Entities;

        public RepositoryBase(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            Entities = _contextFactory.DbContext.Set<TEntity>();
        }

        public BeautyProContext Context
        {
            get
            {
                return _contextFactory.DbContext;
            }
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public TEntity Get(int id)
        {
            return Entities.Find(id);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.SingleOrDefault(predicate);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.FirstOrDefault(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Single(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public virtual IQueryable<TEntity> All
        {
            get { return ObjectQuery; }
        }

        protected virtual IQueryable<TEntity> ObjectQuery
        {
            get
            {
                return Entities;
            }
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void SaveChanges()
        {

            try
            {
                _contextFactory.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //create validadtion exception message
                //var errMsg = "";
                //foreach (var error in ex.EntityValidationErrors)
                //{
                //    foreach (var valid in error.ValidationErrors)
                //    {
                //        errMsg += Environment.NewLine + $"{valid.PropertyName}: {valid.ErrorMessage}";
                //    }
                //}
                throw new Exception("SaveChanges validation error:" + ex);
            }
            //catch (Exception e)
            //{
            //    throw;
            //}
        }
    }
}
