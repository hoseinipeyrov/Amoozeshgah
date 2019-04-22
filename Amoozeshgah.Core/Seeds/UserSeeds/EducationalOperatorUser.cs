using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class LanguageCenterUserRoleSeed
    {
        public static void VandGrow(IDbContext context)
        {
            context.Set<Person>().AddOrUpdate(
                  new Person
                  {
                      FirstName = "سید هادی",
                      LastName = "حسینی پیرو",
                      BirthDate = DateTime.Now,
                      BirthDateJalali = "1366",
                      NationalCode = "3875717661",
                      CreatedBy = "System Seed",
                      User = new User
                      {
                          UserName = "Hadi",
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
                      Id = 1,
                      UserName = "Hadi",
                      Password = "123456",
                      Status = true,
                      CreatedBy = "System Seed",
                  }
           );
            context.SaveChanges();

            context.Set<SiteUserRole>().AddOrUpdate(
                new SiteUserRole { SiteId = 1, UserId = 1, RoleId = 1, CreatedBy = "System Seed" }
         );
            context.SaveChanges();

        }
    }
}
