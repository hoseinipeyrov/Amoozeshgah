using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Core.Seeds
{
    public class EducationalCenterUserSeed
    {
        public static void VandGrow(IDbContext context)
        {
            context.Set<Person>().AddOrUpdate(
                p => p.NationalCode,
                  new Person
                  {
                      FirstName = "کاربر آموزشگاه یک",
                      LastName = "کاربر آموزشگاه یک",
                      BirthDate = DateTime.Now,
                      SexId = 1,
                      BirthDateJalali = "1346",
                      NationalCode = "3875717669",
                      CreatedBy = "System Seed",
                      User = new User
                      {
                          UserName = "EDUser",
                          Password = "EDUser",
                          Status = true,
                          CreatedBy = "System Seed",
                          CreatedDate = DateTime.Now,
                          EducationalCenterUser = new EducationalCenterUser
                          {
                              HireDate = DateTime.Now
                          }
                      }
                  }
           );
            context.SaveChanges();
            //   context.Set<SiteUserRole>().AddOrUpdate(
            //       new SiteUserRole { SiteId = 1, UserId = 2, RoleId = 2, CreatedBy = "System Seed" }
            //);
            //   context.SaveChanges();

        }
    }
}
