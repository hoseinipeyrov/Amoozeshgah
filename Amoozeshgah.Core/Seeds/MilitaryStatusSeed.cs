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
   public class MilitaryStatusSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<MilitaryStatus>().AddOrUpdate(
                c => c.Name,
                new MilitaryStatus { Name = "دارای گواهینامه پایان خدمت", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new MilitaryStatus { Name = "معافیت پزشکی", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new MilitaryStatus { Name = "معافیت دائم", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new MilitaryStatus { Name = "معافیت موقت", CreatedBy = "System Seed", CreatedDate = DateTime.Now }


            );
            context.SaveChanges();
        }
    }
}
