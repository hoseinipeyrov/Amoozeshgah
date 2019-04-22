using Amoozeshgah.Core.UoW;
using System.Collections.Generic;

using System;
using System.Linq;
using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;
using System.Threading.Tasks;

namespace Amoozeshgah.Services
{
    public class SexService : Service, ISexService
    {
        public SexService(IUnitOfWork uow) : base(uow) { }

        public IEnumerable<Sex> GetAll()
        {
            return uow.Repository<Sex>().GetAll().ToList();
        }
       
    }

}
