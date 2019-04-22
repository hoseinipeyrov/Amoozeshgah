using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Amoozeshgah.Core.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, IBaseEntity
    {
        private readonly IDbContext _context;
        private IQueryable<T> _query;

        public Repository(IDbContext context)
        {
            this._context = context;
            _query = context.Set<T>();
        }

        /// <summary>
        /// Get all the list
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            return GetQueryable(filter, orderBy, includeProperties, skip, take);
        }
        protected virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null)
        {
            includeProperties = includeProperties ?? string.Empty;
            if (filter != null)
            {
                _query = _query.Where(filter);
            }

            if (includeProperties.Length > 0)
            {
                foreach (var includeProperty in includeProperties.Split
                 (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    _query = _query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                _query = orderBy(_query);
            }

            if (skip.HasValue)
            {
                _query = _query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                _query = _query.Take(take.Value);
            }

            return _query;
        }

        /// <summary>
        /// Get a certain element of the list
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T Get(Func<T, bool> predicate)
        {
            return _query.FirstOrDefault(predicate);
        }
        /// <summary>
        /// Add a new element to the list
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Create(T entity, string createdBy = null)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = createdBy;
            _context.Set<T>().Add(entity);
        }
        /// <summary>
        /// Update a certain element
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            _context.Set<T>().AddOrUpdate(entity);
        }
        /// <summary>
        /// Delete an element from the list
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        ///////////////////////////


    }
}
