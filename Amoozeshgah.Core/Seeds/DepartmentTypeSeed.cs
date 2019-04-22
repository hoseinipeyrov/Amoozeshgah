using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class DepartmentTypeSeed
    {
        public static void VandGrow(IDbContext context)
        {
            context.Set<DepartmentType>().AddOrUpdate(
                  new DepartmentType { Name= "Age Base", NameFa= "رده بندی سنی", CreatedBy="System Seed",CreatedDate=DateTime.Now}
           );
            context.SaveChanges();

        }
    }
}
