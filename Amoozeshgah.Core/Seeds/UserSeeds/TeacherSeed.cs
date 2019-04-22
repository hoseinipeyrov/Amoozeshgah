using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class TeacherSeed
    {
        public static void VandGrow(IDbContext context)
        {
            context.Set<Person>().AddOrUpdate(
                p=>p.NationalCode,
                  new Person
                  {
                      FirstName = "محمد",
                      LastName = "صالحی",
                      BirthDate = DateTime.Now,
                      SexId=1,
                      BirthDateJalali = "1346",
                      NationalCode = "3875717666",
                      CreatedBy = "System Seed",
                      CreatedDate=DateTime.Now,
                      User = new User
                      {
                          UserName = "salehi",
                          Password = "123456",
                          Status = true,
                          CreatedBy = "System Seed",
                          CreatedDate = DateTime.Now,
                          Teacher = new Teacher
                          {
                              TeacherCode = 91991,
                              FatherName = "xcvvv",
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
