using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Core.Seeds.UserSeeds
{
    class MinistryOfEducationUserSeed
    {
        public static void VandGrow(IDbContext context)
        {
            context.Set<Person>().AddOrUpdate(
                  new Person
                  {
                      FirstName = "وزیر",
                      LastName = "آموزش و پرورش",
                      BirthDate = DateTime.Now,
                      BirthDateJalali = "1366",
                      NationalCode = "3875717661",
                      CreatedBy = "System Seed",
                      User = new User
                      {
                          Id = 2,
                          UserName = "Vazir",
                          Password = "123456",
                          Status = true,
                          CreatedBy = "System Seed",
                      }
                  }
           );
            context.SaveChanges();
            context.Set<User>().AddOrUpdate(
                  new User
                  {
                      Id = 2,
                      UserName = "Vazir",
                      Password = "123456",
                      Status = true,
                      CreatedBy = "System Seed",
                  }
           );
            context.SaveChanges();

         //   context.Set<OrganizationUserRole>().AddOrUpdate(
         //       new OrganizationUserRole { OrganizationId = 1, RoleId = 1, UserId = 2, CreatedBy = "System Seed",CreatedDate=DateTime.Now }
         //);
         //   context.SaveChanges();

        }
    }
}
