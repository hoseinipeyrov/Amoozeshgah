using Amoozeshgah.Core.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Services
{
    public class Service
    {
        public readonly IUnitOfWork uow = null;
        public Service(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
