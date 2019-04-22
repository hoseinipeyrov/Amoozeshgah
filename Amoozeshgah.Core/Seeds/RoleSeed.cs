using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class RoleSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<Role>().AddOrUpdate(
                r=>r.Code,
                new Role { Code = 1, Name = "Setad", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new Role { Code = 2, Name = "ProvinceUser", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new Role { Code = 3, Name = "AreaUser", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new Role { Code = 4, Name = "EducationalCenterUser", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new Role { Code = 5, Name = "Teacher", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                new Role { Code = 6, Name = "Student", CreatedBy = "System Seed", CreatedDate = DateTime.Now });

            context.SaveChanges();
        }
    }
}
