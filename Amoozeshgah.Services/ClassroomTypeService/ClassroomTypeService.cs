using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Core.UoW;

using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Services
{
    public class ClassroomTypeService : Service, IClassroomTypeService
    {
        public ClassroomTypeService(IUnitOfWork uow) : base(uow)
        {
        }
        public IEnumerable<ClassroomType> GetClassroomTypes()
        {
            return uow.Repository<ClassroomType>().GetAll();
        }
    }
}
