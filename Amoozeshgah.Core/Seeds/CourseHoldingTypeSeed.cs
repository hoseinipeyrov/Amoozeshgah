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
    public class CourseHoldingTypeSeed
    {
        public static void VandGrow(IDbContext context)
        {
            context.Set<CourseHoldingType>().AddOrUpdate(
               cht => cht.Name,
                new CourseHoldingType { Code = 1, Name = "حضوری", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
            new CourseHoldingType { Code = 2, Name = "نیمه حضوری", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
            new CourseHoldingType { Code = 3, Name = "غیر حضوری", CreatedBy = "System Seed", CreatedDate = DateTime.Now });
            context.SaveChanges();
        }
    }
}
