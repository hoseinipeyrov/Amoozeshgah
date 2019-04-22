using Amoozeshgah.Core.UoW;
using System.Collections.Generic;
using System;
using System.Linq;
using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Services
{
    public class DashboardService : Service, IDashboardService
    {
        public DashboardService(IUnitOfWork uow) : base(uow)
        {
        }


    }

}
