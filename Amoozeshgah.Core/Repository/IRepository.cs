using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Core.Repo
{
    public interface IRepository<T> where T : BaseEntity, IBaseEntity
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);

        T Get(Func<T, bool> predicate);
        void Create(T entity, string createdBy = null);
        void Update(T entity);
        void Delete(T entity);

    }
}
