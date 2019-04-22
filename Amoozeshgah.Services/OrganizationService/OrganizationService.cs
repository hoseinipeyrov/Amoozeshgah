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
    public class OrganizationService : Service, IOrganizationService
    {
        public OrganizationService(IUnitOfWork uow) : base(uow) { }

        public IEnumerable<Organization> GetAllProvincess()
        {
            return uow.Repository<Organization>().GetAll(p=>p.ParentCode==1);
        }

        public IEnumerable<Organization> GetAllAreas()
        {
            return uow.Repository<Organization>().GetAll(p => p.ParentCode >10 && p.ParentCode <1000);

        }
    }

}
