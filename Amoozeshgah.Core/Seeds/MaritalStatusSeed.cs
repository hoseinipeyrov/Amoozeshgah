using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Seeds
{
  public  class MaritalStatusSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<MaritalStatus>().AddOrUpdate(
                c => c.Name,
                new MaritalStatus { Name = "مجرد", Code = 1, CreatedBy = "System Seed" },
                new MaritalStatus { Name = "متاهل", Code = 2, CreatedBy = "System Seed"}
            );
            context.SaveChanges();
        }
    }
}
