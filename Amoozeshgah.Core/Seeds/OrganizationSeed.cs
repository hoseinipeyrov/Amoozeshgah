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
    class OrganizationSeed
    {
        public static void VandGrow(AppContext context)
        {
           // context.Set<Organization>().AddOrUpdate(
           //       new Organization { Name = "وزارت آموزش و پرورش",PhoneNo="02112345678",
           //                          Address ="تهران",Code=1,AdministratorId=1,
           //                          CreatedBy = "System Seed", CreatedDate = DateTime.Now }
           //);
           // context.SaveChanges();

          //  context.Set<Organization>().AddOrUpdate(
          //       new Organization
          //       {
          //           Name = "تهران",
          //           PhoneNo = "02112345678",
          //           Address = "تهران",
          //           Code = 11,
          //           ParentCode = 1,
          //           AdministratorId = 1,
          //           CreatedBy = "System Seed",
          //           CreatedDate = DateTime.Now
          //       }
          //);
       //     context.SaveChanges();
           // context.Set<Organization>().AddOrUpdate(
           //       new Organization
           //       {
           //           Name = "ناحیه یک",
           //           PhoneNo = "02112345678",
           //           Address = "تهران",
           //           Code = 1111,
           //           ParentCode = 11,
           //           AdministratorId = 1,
           //           CreatedBy = "System Seed",
           //           CreatedDate = DateTime.Now
           //       }
           //);
           // context.SaveChanges();

        }
    }
}
