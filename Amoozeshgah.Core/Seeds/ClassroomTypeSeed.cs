using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class ClassroomTypeSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<ClassroomType>().AddOrUpdate(
                crt => crt.Type,
                  new ClassroomType { Type = "عادی", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                  new ClassroomType { Type = "لابراتور", CreatedBy = "System Seed", CreatedDate = DateTime.Now }
           );

            context.SaveChanges();

        }
    }
}
