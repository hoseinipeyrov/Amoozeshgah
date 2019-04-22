using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Domain.Entities;
using System;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Seeds
{
    public class SexSeed
    {
        public static void VandGrow(AppContext context)
        {
            context.Set<Sex>().AddOrUpdate(
                c=>c.Name,
                  new Sex { Name = "مرد", Title = "پسرانه", CreatedBy = "System Seed", CreatedDate = DateTime.Now },
                  new Sex { Name = "زن", Title = "دخترانه", CreatedBy = "System Seed", CreatedDate = DateTime.Now }
           );
            context.SaveChanges();
        }
    }
}
