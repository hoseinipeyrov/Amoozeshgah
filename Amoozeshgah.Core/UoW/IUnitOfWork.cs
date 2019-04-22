using Amoozeshgah.Core.Repo;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.UoW
{
     public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : BaseEntity,IBaseEntity;

        void SaveChanges();
    }
}
