using System;
using System.Data.Entity.Migrations;
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Core.Seeds
{
    public class EducationDegreeSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<EducationDegree>().AddOrUpdate(
                c => c.Name,
                new EducationDegree { Name = "زیر دیپلم", Code = 1, CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new EducationDegree { Name = "دیپلم", Code = 2, CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new EducationDegree { Name = "فوق دیپلم", Code = 3, CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new EducationDegree { Name = "لیسانس", Code = 4, CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new EducationDegree { Name = "فوق لیسانس", Code = 5, CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new EducationDegree { Name = "دکتری", Code = 6, CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new EducationDegree { Name = "دکتری تخصصی", Code = 7, CreatedBy = "System Seed", CreatedDate = DateTime.Now }
            );
            context.SaveChanges();
        }
    }
}
