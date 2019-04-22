using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Core.Repo;
using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Core.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext context = null;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }

        public IRepository<T> Repository<T>() where T : BaseEntity,IBaseEntity
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }

            var repo = new Repository<T>(context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
