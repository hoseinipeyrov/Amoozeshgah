using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class StudentSeed
    {
        public static void VandGrow(IDbContext context)
        {
            context.Set<Person>().AddOrUpdate(
                p=>p.NationalCode,
                  new Person
                  {
                      FirstName = "فراگیر",
                      LastName = "فراگیر",
                      BirthDate = DateTime.Now,
                      SexId=1,
                      BirthDateJalali = "1346",
                      NationalCode = "3875717660",
                      CreatedBy = "System Seed",
                      CreatedDate=DateTime.Now,
                      User = new User
                      {
                          UserName = "faragir",
                          Password = "faragir",
                          Status = true,
                          CreatedBy = "System Seed",
                          CreatedDate = DateTime.Now,
                          Student = new Student
                          {
                              CityOfBirthId = 1,
                              CityOfHomeId = 1,
                              CreatedDate = DateTime.Now
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
