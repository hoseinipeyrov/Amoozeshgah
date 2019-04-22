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
   public class ReligionSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<Religion>().AddOrUpdate(
                c => c.Name,
                new Religion { Name = "اسلام", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new Religion { Name = "مسیحیت", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new Religion { Name = "زرتشت", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new Religion { Name = "یهودی", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new Religion { Name = "کلیمی", CreatedBy = "System Seed", CreatedDate = DateTime.Now }
            );
            context.SaveChanges();
        }
    }
}
